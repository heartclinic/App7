using System;
using Xamarin.Forms;

namespace App7
{
	public class ReminderPageCS : ContentPage
	{ public float steps = 0;
        public Label stepLabel;
        public Label calLabel;
        public ReminderPageCS ()
		{   

            Label l1 = new Label
            {
                Text = Helpers.Settings.CurrentStep.ToString(),
                FontSize = 30,
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label l2 = new Label
            {
                Text = "0 кал.",
                FontSize = 20,
                TextColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            Title = "Reminder Page";
			Content = new StackLayout { 
				Children = {
				l1,l2
				}    
			};
            stepLabel = l1;
            calLabel = l2;
           // stepLabel.PropertyChanged += StepLabel_PropertyChanged;
            if (Helpers.Settings.CurrentDay != DateTime.Today.Day.ToString()) {
                Helpers.Settings.CurrentDay = DateTime.Today.Day.ToString();
                Helpers.Settings.BegginingStep = 0;
            } 
		}

       

        protected override void OnAppearing()
        {
            DependencyService.Get<DependencySvcStepCounter.IStepCounterDep>().GetSteps((steps) =>
            {
                // Label.Steps = steps;
                stepLabel.Text = steps.ToString();
                calLabel.Text = Fiziology.Convertion.StepsToCall(steps).ToString("#.00") + " кал.";

            });

        }

    }
}
