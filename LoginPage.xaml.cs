using System;
using System.Collections.Generic;
using System.IO;
using JOURNAL.Tables;
using SQLite;
using Xamarin.Forms;

namespace JOURNAL.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegisterUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if (myquery !=null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage()); // functia cu care se navigheaza de la o pagina la alta
            }
            else
            {
                {
                    var result = await this.DisplayAlert("Error", "Try again", "Ok", "Close");

                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                };
            }

        }
    }
}
