using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMenu.Data;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinMenu
{
    public partial class App : Application
    {
        private static FoodItemsDatabase db; // przechowywanie obiektu operowania na bazie danych

        public static FoodItemsDatabase DB
        {
            get
            {
                if (db == null) // utworzenie obiektu dostępu do bazy danych - ścieżka do predefiniowanego folderu lokalnego urządzenia przenośnego
                {
                    db = new FoodItemsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodItems.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = (Color)Resources["darkToolbar"],
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
