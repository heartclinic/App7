using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            // MainPage = new App7.MainPageCS();
           // if (Application.Current.Properties.ContainsKey("id"))
           if (Helpers.Settings.UserLog!="")
            {
              //  var id = Application.Current.Properties["id"].ToString();
                // do something with id
                MainPage = new MainPageCS();
            }
            else
            { MainPage = new RegistrationWithoutPasswordCS();
                //MainPage = new NavigationPage(new WelcomePageCS());

            }
        }

        protected override void OnStart()
        {
            
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

