using ChartChecker.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChartChecker.Models.Database
{
    public class ChartData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ChartType ChartType { get; set; }

        [Required]
        public DateTime ChartDate { get; set; }

        [Required]
        public string Data { get; set; }
    }
}
