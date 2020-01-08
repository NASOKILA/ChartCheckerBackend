using System;
using System.ComponentModel.DataAnnotations;

namespace ChartChecker.Models.Database
{
    public class ChartCheck
    {
        [Key]
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public string Store { get; set; }

        public string ChartType { get; set; }

        public string ImagePath { get; set; }

        public DateTime EventDateTime { get; set; }
    }
}
