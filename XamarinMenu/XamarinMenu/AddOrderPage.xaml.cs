using System;
using System.Collections.Generic;
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
	public partial class AddOrderPage : ContentPage
	{
        Order newOrder;
        public AddOrderPage (List<FoodItem> foodItems)
		{
            InitializeComponent ();
		}

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            var foodItems = await App.DB.getFoodItemsAsync();
            foodItemsPicker.ItemsSource = foodItems;
            menuGroupsPicker.ItemsSource = new MenuGroupsViewModel(foodItems).MenuGroups;
            
            newOrder = new Order() { TotalPrice = 0, CreatedDate = DateTime.Now };
            BindingContext = newOrder;
        }

        private void PlaceOrderBtn_Clicked(object sender, EventArgs e)
        {
            //newOrder = new Order() { TotalPrice = }
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