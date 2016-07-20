using App7.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class RegistrationWithoutPasswordCS : ContentPage
    {
        public Entry ent1, ent2, ent3, ent4;
        ActivityIndicator loadingStatus;
        public RegistrationWithoutPasswordCS()
        {
            Button button1 = new Button //кнопка отправить 
            {

                Text = "Регистрация",

            };
            Label l1 = new Label //текст Login
            {
                XAlign = TextAlignment.Center,
                Text = "Введите свое Имя",
                TextColor = Color.Gray
            };
            Label l2 = new Label
            {

                XAlign = TextAlignment.Center,
                Text = "Ваш рост",
                TextColor = Color.Gray

            };
            Label l3 = new Label
            {

                XAlign = TextAlignment.Center,
                Text = "Вес",
                TextColor = Color.Gray

            };
            Label l4 = new Label
            {

                XAlign = TextAlignment.Center,
                Text = "Возраст",
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
               Keyboard = Keyboard.Numeric
            };
            Entry entr3 = new Entry
            {
                Placeholder = "",
                TextColor = Color.Red,
                PlaceholderColor = Color.Gray,
                Keyboard = Keyboard.Numeric
            };
            Entry entr4 = new Entry
            {
                Placeholder = "",
                TextColor = Color.Red,
                PlaceholderColor = Color.Gray,
                Keyboard = Keyboard.Numeric
               

            };
            ActivityIndicator loadIndicator = new ActivityIndicator {
                IsRunning = false,
                Color = Color.Red
            };
            Title = "Регистрация";
            Content = new ScrollView
            {
                Content =new StackLayout
                    {
                        BackgroundColor = Color.White,

                        VerticalOptions = LayoutOptions.Center,
                        Children = {
                            l1,entr1,l2,entr2,l3,entr3,l4,entr4,button1, loadIndicator//добавляем элементы в том порядке в котором они должны идти
                            }
                    }
            };
            button1.Clicked += Button1_Clicked; //добавляем метод Button1_Clicked на клик кнопки
            ent1 = entr1; //создаем ссылки на элементы управления
            ent2 = entr2;
            ent3 = entr3;
            ent4 = entr4;
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
     /*   User response = await fbc.GetUser("users/" + ent1.Text); //делаем запрос на наличие в базе данных пользователя
            if (response != null) //если тело ответа на запрос не пустое, значит пользователь такой пользователь есть
            {
                loadingStatus.IsRunning = false;
                await DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "OK"); //выводим окошко с ошибкой
            }
            else
            {*/
                values.Add("name", ent1.Text);
                values.Add("height", ent2.Text); //добавляем введенные значения в словарь
                values.Add("weight", ent3.Text);
                values.Add("age", ent4.Text);
            string uid = DependencyService.Get<DependencySvcDevice.IDevice>().GetIdentifier();
            User2 response = await fbc.Update2("users/" + ent1.Text + "_" +uid, values);
                if (response != null) //если тело ответа на запрос не пустое, значит пользователь такой пользователь есть
                {
                    loadingStatus.IsRunning = false;
                    // Application.Current.Properties["id"] = ent1.Text;
                    Helpers.Settings.UserLog = ent1.Text;
                //  await DisplayAlert("Готово", "Успешный вход", "OK");
                
                await Navigation.PushModalAsync(new MainPageCS());
            
                }
         }
    }
}
