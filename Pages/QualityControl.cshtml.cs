using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentComplaintSystem.Pages
{
    public class QualityControlModel : PageModel
    {
        private readonly AppDbContext _context;

        public QualityControlModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Complaint> Complaints { get; set; } = new();

        public int OverdueCount { get; set; }

        public Dictionary<string, int> CategoryStats { get; set; } = new();

        public string MostComplainedCategory { get; set; } = "";
        public string LeastComplainedCategory { get; set; } = "";
        public int TotalResolved { get; set; }

        public void OnGet(string? status, string? category, string? level, string? matricNumber)
        {
            var query = _context.Complaints.AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(c => c.Status == status);

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(c => c.Category == category);

            // SAFE FIX (prevents string/int crash)
            if (!string.IsNullOrWhiteSpace(level))
                query = query.Where(c => c.Level.ToString() == level);

            if (!string.IsNullOrWhiteSpace(matricNumber))
                query = query.Where(c => c.MatricNumber.Contains(matricNumber));

            Complaints = query.ToList();

            OverdueCount = Complaints.Count(c =>
                c.Status == "Pending" &&
                (DateTime.Now - c.DateSubmitted).TotalDays > 7);

            CategoryStats = Complaints
                .GroupBy(c => c.Category)
                .ToDictionary(g => g.Key, g => g.Count());

            if (CategoryStats.Any())
            {
                MostComplainedCategory = CategoryStats
                    .OrderByDescending(x => x.Value)
                    .First().Key;

                LeastComplainedCategory = CategoryStats
                    .OrderBy(x => x.Value)
                    .First().Key;
            }

            TotalResolved = Complaints.Count(c => c.Status == "Fully Resolved");
        }
    }
}