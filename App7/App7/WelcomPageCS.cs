using App7.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class WelcomePageCS : ContentPage
    {
        public Entry ent1, ent2, ent3, ent4;
        public WelcomePageCS()
        {
            string s= "У меня уже есть учетная запись";
            if (Application.Current.Properties.ContainsKey("id"))
            {
                s= Application.Current.Properties["id"].ToString();
            }
                Button button1 = new Button //кнопка отправить
            {

                Text = s,

            };
            Button button2 = new Button //кнопка отправить
            {

                Text = "Зарегистрировать новый аккаунт",

            };
            Label l1 = new Label //текст Login
            {
                XAlign = TextAlignment.Center,
                Text = "Добро пожаловать в приложение Клиники Сердца",
                TextColor = Color.Gray
            };
            Label l2 = new Label
            {

                XAlign = TextAlignment.Center,
                Text = "Для начала использования войдите в свой аккаунт",
                TextColor = Color.Gray

            };
           
            Title = "Клиника Сердца";
            Content = new StackLayout
            {
                BackgroundColor = Color.White,

                VerticalOptions = LayoutOptions.Center,
                Children = {
                    l1,l2,button1, button2//добавляем элементы в том порядке в котором они должны идти
                    }
            };
            button1.Clicked += Button1_Clicked; //добавляем метод Button1_Clicked на клик кнопки
            button2.Clicked += Button2_Clicked;
        }

        private async void Button2_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync (new RegistrationWithoutPasswordCS ());
            
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginCS());
        }
     
    }
}
