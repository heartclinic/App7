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
                s = Helpers.Settings.UserLog;
            };
                Button button1 = new Button //кнопка отправить
            {

                Text = "Регистрация",

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
                    l1
                    }
            };
          
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            sendrequest();
        }
        async void sendrequest()
        {
            FireBaseConnect fbc = new FireBaseConnect();
            Dictionary<string, string> values = new Dictionary<string, string>(); //создаем словарь типа ключ значение, для передачи переменных
          string response = await fbc.Get("users/" + ent1.Text); //делаем запрос на наличие в базе данных пользователя
            if (response != "null") //если тело ответа на запрос не пустое, значит пользователь такой пользователь есть
            {
                await DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "OK"); //выводим окошко с ошибкой
            }
            else
            {
                values.Add("password", ent2.Text); //добавляем введенные значения в словарь
                values.Add("name", ent3.Text);
                values.Add("surname", ent4.Text);
                fbc.Update("users/" + ent1.Text, values);
                //response = await client.UpdateAsync("users/" + ent1.Text, values);//добавляем данные в БД

                //Dictionary<string, string> result = response.ResultAs<Dictionary<string, string>>();
            }

        }
    }
}
