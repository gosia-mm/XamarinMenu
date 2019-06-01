using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMenu.Data;
using XamarinMenu.Models;

namespace XamarinMenu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var menuItems = await App.DB.getMenuItemsAsync();
            menuItems.ForEach(td => td.Image = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), td.Image + ".jpg"));

            menuListView.ItemsSource = MenuGroups.MenuGroupsList(menuItems);
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
            await Navigation.PushAsync(new AddOrderPage()
            {
            });
        }
    }
}
