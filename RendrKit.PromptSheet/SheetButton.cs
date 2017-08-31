using System;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
	public class SheetButton : Button
	{
        public static readonly BindableProperty TextAlignmentProperty =
            BindableProperty.Create("TextAlignment", typeof(TextAlignment), typeof(TextAlignment), TextAlignment.Center);
				

		public TextAlignment TextAlignment
		{
			get { return (TextAlignment)this.GetValue(TextAlignmentProperty); }
			set { this.SetValue(TextAlignmentProperty, value); }
		}

		private static void OnTextAlignmentChanged(BindableObject bindable, TextAlignment oldvalue, TextAlignment newValue)
		{
            var button = (SheetButton)bindable;
			button.TextAlignment = newValue;
		}

        public SheetButton()
		{
		}


	}
}
