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
    }
}