using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersPage : ContentPage
	{
		public OrdersPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var orders = await App.DB.getOrdersAsync();
            //orders.ForEach(td => td.Image = Path.Combine(Environment.GetFolderPath(
            //        Environment.SpecialFolder.LocalApplicationData), td.Image + ".jpg"));

            //menuListView.ItemsSource = MenuGroups.ToDosGroupsList(orders);
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