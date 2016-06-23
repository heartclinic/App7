using Xamarin.Forms;

namespace App7
{
	public class ReminderPageCS : ContentPage
	{ public float steps = 0;
        public Label stepLabel;
		public ReminderPageCS ()
		{
            Label l1 = new Label
            {
                Text = "Reminder data goes here",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Title = "Reminder Page";
			Content = new StackLayout { 
				Children = {
				l1	
				}    
			};
            stepLabel = l1;

		}
        protected override void OnAppearing()
        {
            DependencyService.Get<DependencySvcStepCounter.IStepCounterDep>().GetSteps((steps) =>
            {
                // Label.Steps = steps;
                stepLabel.Text = steps.ToString(); 
                
            });

        }

    }
}
