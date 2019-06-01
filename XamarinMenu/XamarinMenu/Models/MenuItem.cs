using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace XamarinMenu.Models
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [PrimaryKey, AutoIncrement]
        public int MenuItemID { get; set; }
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
