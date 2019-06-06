using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XamarinMenu.Models
{
    public class MenuGroup : List<FoodItem>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}
