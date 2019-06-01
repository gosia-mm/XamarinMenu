using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMenu.Models
{
    class OrderWithFoodItem
    {
        [ForeignKey(typeof(MenuItem))]
        public int MenuItemID { get; set; }

        [ForeignKey(typeof(Order))]
        public int OrderID { get; set; }
    }
}
