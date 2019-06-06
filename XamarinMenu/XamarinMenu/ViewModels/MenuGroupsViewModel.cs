using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinMenu.Models;

namespace XamarinMenu.ViewModels
{
    class MenuGroupsViewModel
    {
        public List<MenuGroup> MenuGroups { get; private set; }

        public MenuGroupsViewModel(List<FoodItem> foodItems)
        {
            MenuGroups = new List<MenuGroup>();

            var groupsNames = foodItems.Select(mi => mi.Category).Distinct().OrderBy(mi => mi);

            foreach (var groupName in groupsNames)
            {
                var foodItemsInGroup = foodItems.Where(t => t.Category == groupName);
                var newGroup = new MenuGroup()
                {
                    Title = groupName == null ? "Brak" : groupName,
                    ShortTitle = groupName == null ? "Brak" : groupName,
                };
                newGroup.AddRange(foodItemsInGroup);
                MenuGroups.Add(newGroup);
            }
        }
    }
}
