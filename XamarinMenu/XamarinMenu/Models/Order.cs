using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace XamarinMenu.Models
{
    [Table("Orders")]
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int OrderID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }

        [ManyToMany(typeof(MenuItem))]
        public List<MenuItem> MenuItems { get; set; }
    }
}
