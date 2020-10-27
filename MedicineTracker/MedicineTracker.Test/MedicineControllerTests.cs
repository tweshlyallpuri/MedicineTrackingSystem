using MedicineTracker.Controllers;
using MedicineTracker.Data.Database;
using MedicineTracker.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MedicineTracker.Test
{
    public class MedicineControllerTests
    {
        private InMemoryMedicinesContext ArrangeDb()
        {
            //Arrange
            var context = new InMemoryMedicinesContext();
            context.Medicines = new List<Medicine>()
            {new Medicine(){FullName = "Crocin",BrandName="NHL",Price=12.5678,Quantity=51,ExpiryDate = DateTime.Now.AddDays(365),Notes="Sample note"},
            new Medicine(){FullName = "Diegene",BrandName="BPL",Price=25.12,Quantity=75,ExpiryDate = DateTime.Now.AddDays(150),Notes="Sample note 2"}
            };
            return context;
        }
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfMedicines()
        {
            //Arrange
            var context = ArrangeDb();
            var controller = new MedicineController(null,context);
            int medicineCount = context.Medicines.Count();
            //Act
            var result = controller.Index();
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Medicine>>(
                viewResult.ViewData.Model);
            Assert.Equal(medicineCount, model.Count());
        }
        [Fact]
        public void Task_Add_ValidData_ReturnRedirectResult_And_UpdatedCount()
        {
            //Arrange
            var context = ArrangeDb();
            var controller = new MedicineController(null, context);
            int initialMedicineCount = context.Medicines.Count();
            var medicine = new Medicine() { FullName = "Crocin3", BrandName = "BPQ", Price = 35.26, Quantity = 126, ExpiryDate = DateTime.Now.AddDays(200), Notes = "Sample note" };
            //Act 
            var result = controller.Create(medicine);

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(initialMedicineCount + 1, context.Medicines.Count());
        }
        [Fact]
        public void Details_ReturnsAViewResult_WithMedicineDetails()
        {
            //Arrange
            var context = ArrangeDb();
            var controller = new MedicineController(null, context);
            var medicine = context.Medicines[0];
            //Act
            var result = controller.Details(medicine.FullName);
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Medicine>(
                viewResult.ViewData.Model);
            Assert.Equal(medicine, model);
        }
    }
}
