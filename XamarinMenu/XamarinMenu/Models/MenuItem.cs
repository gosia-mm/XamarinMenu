using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMenu.Models
{
    public class MenuItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }
}
