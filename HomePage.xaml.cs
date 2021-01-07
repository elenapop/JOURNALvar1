using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using JOURNAL.Views;
using JOURNAL.Tables;
using JOURNAL;

namespace JOURNAL
{
    public partial class HomePage : ContentPage
    {

        private object ListView;

        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetRegisterCityTableAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityName.Text) && !string.IsNullOrWhiteSpace(CityCountry.Text))
            {
                await App.Database.SaveCityAsync(new City
                {
                    CityName = CityName.Text,
                    CityCountry = int.Parse(CityCountry.Text)
                });

                CityName.Text = CityCountry.Text = string.Empty;
                listView.ItemsSource = await App.Database.GetRegisterCityTableAsync();
            }
        }


        public HomePage()
        {
            SetValue(NavigationPage.HasBackButtonProperty, false);
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}
