using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinMenu.Data;
using XamarinMenu.Models;
using XamarinMenu.ViewModels;

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

            var foodItems = await App.DB.getFoodItemsAsync();


            /* Wykorzystanie CHMURY */
            //var response = await new Services.MenuRestService().Client.GetAsync("  nasz link do azure website   ");  // pobranie z chmury
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var menusCloudJSON = await response.Content.ReadAsStringAsync(); // wyciągniecie zawartości
            //    foodItems.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<FoodItem>>(menusCloudJSON));
            //}
            /* KONIEC */


            foodItems.ForEach(td => td.Image = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), td.Image + ".jpg"));

            var menugroupsvm = new MenuGroupsViewModel(foodItems);

            menuListView.ItemsSource = menugroupsvm.MenuGroups;




            // menuListView.ItemsSource = MenuGroups.MenuGroupsList(foodItems);   pierwotna wersja z zajęć
        }
        async private void AddItem_Clicked(object sender, EventArgs e)
        {
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

        async private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
                System.Threading.Thread.Sleep(3000);
                await Flashlight.TurnOffAsync();
                Vibration.Vibrate(3000);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Błąd 1", ex.Message, "ok");
            }
            catch (PermissionException ex)
            {
                await DisplayAlert("Błąd 2", ex.Message, "ok");
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }
                await DisplayAlert("Błąd 2", inner.Message, "ok");
            }

            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new FoodItemPage()
                {
                    BindingContext = e.SelectedItem as FoodItem
                });
            }
        }
    }
}
