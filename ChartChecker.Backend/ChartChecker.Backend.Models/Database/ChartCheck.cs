using System;
using System.ComponentModel.DataAnnotations;

namespace ChartChecker.Backend.Models.Database
{
    public class ChartCheck
    {
        [Key]
        public int Id { get; set; }

        public string UniqueId { get; set; }

        public string UserEmail { get; set; }

        public string StoreName { get; set; }

        public DateTime EventTime { get; set; }

        public string ImagePath { get; set; }
    }
}
