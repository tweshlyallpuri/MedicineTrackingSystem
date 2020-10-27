using MedicineTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineTracker.Data.Database
{
    public interface IInMemoryMedicines
    {
        public List<Medicine> Medicines { get; set; }
    }
}
