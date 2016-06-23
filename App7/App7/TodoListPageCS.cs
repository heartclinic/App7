using Xamarin.Forms;

namespace App7
{
	public class TodoListPageCS : ContentPage
	{
		public TodoListPageCS ()
		{
			Title = "TodoList Page";
            BackgroundColor = Color.White;
           
			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "Todo list data goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}
