using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineTracker.Data.Models
{
    public class Medicine
    {
        public string FullName { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
