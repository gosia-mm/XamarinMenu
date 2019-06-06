using System;
using System.Collections.Generic;
using System.Text;
using XamarinMenu.Models;

namespace XamarinMenu.ViewModels
{
    class FoodItemsViewModel
    {
        public List<FoodItem> FoodItems { get; private set; }

        public FoodItemsViewModel()
        {
            FoodItems = new List<FoodItem>();

            //FoodItems.Add(new FoodItem
            //{
            //    Name = "Pizza",
            //    Category = "Danie główne"
            //});

        }
    }
}
