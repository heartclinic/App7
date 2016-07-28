using Xamarin.Forms;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace App7
{
	public class TodoListPageCS : ContentPage
	{
        double distance = 0;
        double lat1 = 0;
        double lon1 = 0;
        Label l1 = new Label
        {
            Text = "Todo list data goes here",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public TodoListPageCS ()
        {
            var buttonGetGPS = new Button
            {
                Text = "GetGPS"
            };

            var labelGPS = new Label
            {
                Text = "GPS goes here"
            };
            var locator = CrossGeolocator.Current;
            buttonGetGPS.Clicked += async (sender, args) =>
            {
              
                locator.DesiredAccuracy = 50;
                labelGPS.Text = "Getting gps";

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                if (position == null)
                {
                    labelGPS.Text = "null gps :(";
                    return;
                }
                labelGPS.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}",
                  position.Timestamp, position.Latitude, position.Longitude,
                  position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
                await locator.StartListeningAsync(minTime: 1000, minDistance: 0);
                locator.PositionChanged += (sender2, e) => {
                   

                    position = e.Position;
                    if (lat1 == 0)
                    {
                        lat1 = position.Latitude;
                        lon1 = position.Longitude;
                    }
                    else {
                        distance += GPS.Utils.distance(lat1, lon1, position.Latitude, position.Longitude, 'K');
                        lat1 = position.Latitude;
                        lon1 = position.Longitude;
                    }
                    labelGPS.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}  \n Distance: {8} ",
                  position.Timestamp, position.Latitude, position.Longitude,
                  position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed,distance);
                   
                };
            };


            Title = "TodoList Page";
            BackgroundColor = Color.White;
           
			Content = new StackLayout { 
				Children = {
                buttonGetGPS,
            labelGPS
                }
			};
          

        }
        public async void RunGPS() {/*
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                Console.WriteLine("Position Status: {0}", position.Timestamp);
                Console.WriteLine("Position Latitude: {0}", position.Latitude);
                Console.WriteLine("Position Longitude: {0}", position.Longitude);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
       */ }
    }
}
