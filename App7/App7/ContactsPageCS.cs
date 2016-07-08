using App7.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class ContactsPageCS : ContentPage
    {
        public Entry ent1, ent2, ent3, ent4;
        public ContactsPageCS()
        {
            string s = "Логин";
            if (Helpers.Settings.UserLog!="")
            {
                s = "Привет! \n" + Helpers.Settings.UserLog;
            };
                Button button1 = new Button //кнопка отправить
            {

                Text = "Выйти",

            };
            Label l1 = new Label //текст Login
            {
                XAlign = TextAlignment.Center,
                Text = s,
                TextColor = Color.Gray
            };
            
            Title = "Клиника Сердца";
            Content = new StackLayout
            {
                BackgroundColor = Color.White,

                VerticalOptions = LayoutOptions.Center,
                Children = {
                    l1,button1
                    }
            };
            button1.Clicked += Button1_Clicked;
          
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            Helpers.Settings.UserLog = "";
          //  await Navigation.PushAsync(new WelcomePageCS());
            Application.Current.MainPage = new NavigationPage(new WelcomePageCS());
        }
        
    }
}
