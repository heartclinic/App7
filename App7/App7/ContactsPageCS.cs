using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class ContactsPageCS : ContentPage
    {
        public ContactsPageCS()
        {

            Title = "Клиника Сердца";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Contacts data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }

                }
            };
        }
    }
}
