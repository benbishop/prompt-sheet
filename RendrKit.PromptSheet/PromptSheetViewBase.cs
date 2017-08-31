using System;
using Xamarin.Forms;
namespace RendrKit.PromptSheet
{
    public abstract class PromptSheetViewBase:SheetViewBase
    {
        protected PromptSheetViewBase(SheetViewStyle style):base(style)
        {
        }

        protected Grid CreateGrid(Thickness padding, int numberofRows){
			var grid = new Grid()
			{
				BackgroundColor = Color.Transparent,
                Padding = padding,
				RowDefinitions = new RowDefinitionCollection()
				{
				}
			};

            for (var i = 0; i < numberofRows; i++)
				grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            return grid;
        }

        protected Label CreateLabel(SheetLabelStyle style, string text){
            var label = new Label()
            {
                Text = text
            };
            style.ApplyTo(label);
            return label;
        }

        protected SheetButton CreateSheetButton(SheetButtonStyle style, string text)
        {
            var button = new SheetButton()
            {
                Text = text
            };

            style.ApplyTo(button);
            return button;
        }

		protected Entry CreateEntry(SheetEntryStyle style, InputOptions inputOptions)
		{
			var button = new Entry()
			{
				Placeholder = inputOptions.Placeholder
			};

			style.ApplyTo(button);
			return button;
		}
    }
}
