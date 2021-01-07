using System;
using System.IO;
using JOURNAL.Tables;
using JOURNAL.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JOURNAL
{
    public partial class App : Application
    {

        static RegisterCityTable database;

        public static RegisterCityTable Database
        {
            get
            {
                if (database == null)
                {
                    database = new RegisterCityTable(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
