using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App7
{
    public class MainPageCS : MasterDetailPage
    {
        MasterPageCS masterPage;

        public MainPageCS()
        {
            /*var existingPages = Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                Navigation.RemovePage(page);
            }*/
         //   this.Navigation.PopAsync();
            masterPage = new MasterPageCS();
            Master = masterPage;
            Detail = new NavigationPage(new ContactsPageCS()) { };
           
            masterPage.ListView.ItemSelected += OnItemSelected;
            int t = 0;
            if (Device.OS == TargetPlatform.Windows)
            { 
                Master.Icon = "swap.png";
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType)) { };
              
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
