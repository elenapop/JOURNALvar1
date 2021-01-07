using System;
using System.Collections.Generic;
using System.IO;
using JOURNAL.Tables;
using SQLite;
using Xamarin.Forms;

namespace JOURNAL.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegisterUserTable>();

            var item = new RegisterUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,

            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "User Registration Succesful", "Ok", "Close");

                if (result)
                    await Navigation.PushAsync(new LoginPage());
            });




        }

    }
}
