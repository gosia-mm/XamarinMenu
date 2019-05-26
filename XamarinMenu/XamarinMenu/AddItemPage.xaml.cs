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
        XamarinMenu.Models.MenuItem newMenuItem;
		public AddItemPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            newMenuItem = new XamarinMenu.Models.MenuItem() { Name = "", Description = "", Category = "Osobiste" };
            BindingContext = newMenuItem;
        }

        async private void BtnAddNewItem_Clicked(object sender, EventArgs e)
        {
            await App.DB.addOrUpdateMenuItemAsync(newMenuItem);
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
    }
}