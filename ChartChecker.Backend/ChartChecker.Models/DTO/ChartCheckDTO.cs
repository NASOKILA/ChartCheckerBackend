using System;

namespace ChartChecker.Models.DTO
{
    public class ChartCheckDTO
    {
        public string UserEmail { get; set; }

        public string StoreName { get; set; }

        public string ChartType { get; set; }

        public string ImagePath { get; set; }
        
        public DateTime EventDateTime { get; set; }
    }
}
