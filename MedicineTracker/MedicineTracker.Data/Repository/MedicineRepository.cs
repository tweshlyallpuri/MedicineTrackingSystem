using MedicineTracker.Data.Database;
using MedicineTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicineTracker.Data.Repository
{
    public class MedicineRepository : IRepository
    {
        public MedicineDbContext MedicineDbContext;
        public MedicineRepository(MedicineDbContext context)
        {
            MedicineDbContext = context;
        }
         public async Task AddNewMedicineAsync(Medicine med)
        {
            MedicineDbContext.Add(med);
            _ = await MedicineDbContext.SaveChangesAsync();
        }
    }
}
