using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XamarinMenu.Models
{
    public class MenuGroup : List<MenuItem>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }

    public class MenuGroups
    {
        public static List<MenuGroup> ToDosGroupsList(List<MenuItem> menuItems)
        {
            var toDosGroups = new List<MenuGroup>();

            var groupsNames = menuItems.Select(mi => mi.Category).Distinct().OrderBy(mi => mi);

            foreach (var groupName in groupsNames)
            {
                var menuItemsInGroup = menuItems.Where(t => t.Category == groupName);
                var newGroup = new MenuGroup() 
                {
                    Title = groupName == null ? "Brak" : groupName,
                    ShortTitle = groupName == null ? "Brak" : groupName,
                };
                newGroup.AddRange(menuItemsInGroup); 
                toDosGroups.Add(newGroup); 
            }

            return toDosGroups;
        }
    }
}
