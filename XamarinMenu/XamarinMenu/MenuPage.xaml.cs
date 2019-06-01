using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMenu.Models;

namespace XamarinMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var menuItems = await App.DB.getMenuItemsAsync();
            menuItems.ForEach(td => td.Image = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), td.Image + ".jpg"));

            menuListView.ItemsSource = MenuGroups.MenuGroupsList(menuItems);
        }
    }
}