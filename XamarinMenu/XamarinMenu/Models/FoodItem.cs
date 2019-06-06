using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMenu.Models
{
    [Table("FoodItems")]
    public class FoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int FoodItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }


        [ManyToMany(typeof(Order))]
        public List<Order> Orders { get; set; }
    }
}
