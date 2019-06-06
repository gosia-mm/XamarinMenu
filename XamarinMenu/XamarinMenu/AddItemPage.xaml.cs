using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMenu.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using XamarinMenu.DependencyInjection;

namespace XamarinMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{
        FoodItem newMenuItem;
		public AddItemPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            newMenuItem = new FoodItem() { Name = "", Description = ""};
            BindingContext = newMenuItem;
        }

        async private void BtnAddNewItem_Clicked(object sender, EventArgs e)
        {
            await App.DB.addOrUpdateFoodItemAsync(newMenuItem);
            await Navigation.PopAsync();
        }

        private async void BtnChooseImg_Clicked(object sender, EventArgs e)
        {
            BtnChooseImg.IsEnabled = false;
            Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

            if (stream != null)
            {
                var imgLocalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), newMenuItem.Image + ".jpg");
                var imgMemory = new MemoryStream();
                stream.CopyTo(imgMemory); // zapisanie obrazka do pamięci RAM
                File.WriteAllBytes(imgLocalPath, imgMemory.ToArray()); // pobranie danych z pamięci RAM
                imgMenuItem.Source = ImageSource.FromFile(imgLocalPath);
                imgMenuItem.BackgroundColor = Color.Gray;
            }

            BtnChooseImg.IsEnabled = true;
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