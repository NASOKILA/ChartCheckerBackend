﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ChartChecker.Models.Database
{
    public class ChartCheck
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string ChartType { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }
    }
}
