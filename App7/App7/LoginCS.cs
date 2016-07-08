using App7.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class LoginCS : ContentPage
    {
        public Entry ent1, ent2, ent3, ent4;
        ActivityIndicator loadingStatus;
        public LoginCS()
        {
            Button button1 = new Button //кнопка отправить 
            {

                Text = "Войти",

            };
            ActivityIndicator loadIndicator = new ActivityIndicator
            {
                IsRunning = false,
                Color = Color.Red
            };
            Label l1 = new Label //текст Login
            {
                XAlign = TextAlignment.Center,
                Text = "Логин",
                TextColor = Color.Gray
            };
            Label l2 = new Label
            {

                XAlign = TextAlignment.Center,
                Text = "Пароль",
                TextColor = Color.Gray

            };
            Entry entr1 = new Entry //Поле ввода для логина
            {

                Placeholder = "",
                TextColor = Color.Red,
                PlaceholderColor = Color.Gray
            };
            Entry entr2 = new Entry
            {
                Placeholder = "",
                TextColor = Color.Red,
                PlaceholderColor = Color.Gray,
                IsPassword = true
            };
            Title = "Вход в учетную запись";
            Content = new StackLayout
            {
                BackgroundColor = Color.White,

                VerticalOptions = LayoutOptions.Center,
                Children = {
                    l1,entr1,l2,entr2,button1,loadIndicator//добавляем элементы в том порядке в котором они должны идти
                    }
            };
            button1.Clicked += Button1_Clicked; //добавляем метод Button1_Clicked на клик кнопки
            ent1 = entr1; //создаем ссылки на элементы управления
            ent2 = entr2;
            loadingStatus = loadIndicator;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            loadingStatus.IsRunning = true;
            sendrequest();
        }
        async void sendrequest()
        {
            FireBaseConnect fbc = new FireBaseConnect();
            Dictionary<string, string> values = new Dictionary<string, string>(); //создаем словарь типа ключ значение, для передачи переменных
         User response = await fbc.GetUser("users/" + ent1.Text); //делаем запрос на наличие в базе данных пользователя
            if (response == null) //если тело ответа на запрос не пустое, значит пользователь такой пользователь есть
            {
                loadingStatus.IsRunning = false;
                await DisplayAlert("Ошибка", "Пользователь с таким именем не найден", "OK"); //выводим окошко с ошибкой
            }
            else
            {
                //response = await fbc.Get("users/" + ent1.Text+"/password");
                if (response.password != ent2.Text) //если тело ответа на запрос не пустое, значит пользователь такой пользователь есть
                {
                    loadingStatus.IsRunning = false;
                    await DisplayAlert("Ошибка", "Пароль не верный", "OK"); //выводим окошко с ошибкой
                }
                else
                {
                    loadingStatus.IsRunning = false;
                    await DisplayAlert("Готово", "Успешный вход", "OK"); //выводим окошко с ошибкой
                   
                    // Application.Current.Properties["id"] = ent1.Text;
                    Helpers.Settings.UserLog = ent1.Text;

                    //  await DisplayAlert("Готово", "Успешный вход", "OK");
                    await Navigation.PushModalAsync(new MainPageCS());
                }
                //response = await client.UpdateAsync("users/" + ent1.Text, values);//добавляем данные в БД

                //Dictionary<string, string> result = response.ResultAs<Dictionary<string, string>>();
            }

        }
    }
}
