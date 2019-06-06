using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMenu.Models;
using XamarinMenu.ViewModels;

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

            var foodItems = await App.DB.getFoodItemsAsync();
            foodItems.ForEach(td => td.Image = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), td.Image + ".jpg"));

            // menuListView.ItemsSource = MenuGroups.MenuGroupsList(foodItems);  pierwotna wersja z zajęć
            var menugroupsvm = new MenuGroupsViewModel(foodItems);

            menuListView.ItemsSource = menugroupsvm.MenuGroups;
        }

        async private void AddItem_Clicked(object sender, EventArgs e)
        {
            //ToDo nowy = new ToDo();
            await Navigation.PushAsync(new AddItemPage()
            {
            });
        }
        async private void MenuView_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new MenuPage()
            {
            });
        }
        async private void AddOrder_Clicked(object sender, EventArgs e)
        {
            var foodItems = await App.DB.getFoodItemsAsync();
            await Navigation.PushAsync(new AddOrderPage(foodItems)
            {
            });
        }
    }
}