using MedicineTracker.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicineTracker.Data.Models
{
    public class Medicine
    {
        public string FullName { get; set; }
        public string BrandName { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Must be greater than 0.")]
        public int Quantity { get; set; }
        [Display(Name = "Expiry Date")]
        [ValidateExpiryDate]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
