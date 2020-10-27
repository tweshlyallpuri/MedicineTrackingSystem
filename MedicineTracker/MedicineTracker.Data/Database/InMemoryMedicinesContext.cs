using MedicineTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineTracker.Data.Database
{
    public class InMemoryMedicinesContext : IInMemoryMedicines
    {
        public List<Medicine> Medicines { get; set; }
        public InMemoryMedicinesContext()
        {
            Medicines = new List<Medicine>()
            {new Medicine(){FullName = "Crocin",BrandName="NHL",Price=12.5678,Quantity=51,ExpiryDate = DateTime.Now.AddDays(365),Notes="Sample note"},
            new Medicine(){FullName = "Diegene",BrandName="BHL",Price=25.12,Quantity=75,ExpiryDate = DateTime.Now.AddDays(150),Notes="Sample note 2"}
            };
        }
    }
}
