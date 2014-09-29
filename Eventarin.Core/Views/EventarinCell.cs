using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace Eventarin.Core.Views
{
	public class EventarinCell : ViewCell
	{
		//Bindable property for the Command
		public static readonly BindableProperty CommandProperty = BindableProperty.Create<EventarinCell, ICommand>(p => p.Command, null);

		//Gets or sets the Command for the MenuCell
		public ICommand Command 
		{
			get 
			{ 
				return (ICommand)GetValue(CommandProperty); 
			}
			set 
			{ 
				SetValue(CommandProperty, value); 
			}
		}

		protected override void OnTapped()
		{
			base.OnTapped();
			if (Command != null && Command.CanExecute(null))
			{
				Command.Execute(null);
			}
		}
	}
}

