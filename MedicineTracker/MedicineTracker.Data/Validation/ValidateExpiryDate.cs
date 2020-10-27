using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTracker.Validation
{
    public class ValidateExpiryDate : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-expiryDate", "Warning : Expiry Date is in less than 30 days");
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((DateTime)value).Date.AddDays(-15) < DateTime.Now.Date)
                return new ValidationResult("Cannot add in stock if Expiry Date is less than 15 days ahead");
            else
                return ValidationResult.Success;
        }
    }
}
