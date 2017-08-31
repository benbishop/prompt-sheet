using System;
using Xamarin.Forms;
using System.Linq;

namespace RendrKit.PromptSheet
{

    public class AlertSheetEventArgs : EventArgs
    {
        public int ButtonIndex { get; }

        public AlertSheetEventArgs(int buttonIndex)
        {
            ButtonIndex = buttonIndex;
        }
    }

    public class AlertSheet : PromptSheetViewBase
    {
        public event EventHandler ButtonTapped = delegate { };

        Label _titleLabel;
        Label _messageLabel;
        SheetButton _okButton;

        readonly AlertSheetStyle style;

        readonly string _title;
        readonly string _message;
        readonly string _primaryButtonText;
        readonly string[] _additionalButtons;

        public AlertSheet(string title, string message, string primaryButtonText, string[] additionalButtons, AlertSheetStyle style) : base(style)
        {
            _additionalButtons = additionalButtons;
            _primaryButtonText = primaryButtonText;
            _message = message;
            _title = title;
            this.style = style;
        }

        protected override View CreateContent()
        {
            var grid = CreateGrid(style.Padding, 3 + _additionalButtons.Count());


            _titleLabel = CreateLabel(style.TitleLabelStyle,_title);

            _messageLabel = CreateLabel(style.BodyLabelStyle, _message);


            grid.Children.Add(_titleLabel, 0, 0);
			grid.Children.Add(_messageLabel, 0, 1);

            _okButton = CreateSheetButton(style.PrimaryButtonStyle, _primaryButtonText);


            _okButton.Clicked += (sender, e) =>
            {
                Hide();
                ButtonTapped(this, new AlertSheetEventArgs(0));
            };


            grid.Children.Add(_okButton, 0, 2);

            for (int i = 0; i < _additionalButtons.Length; i++)
                CreateSecondaryButton(grid, i);


            return grid;
        }

        void CreateSecondaryButton(Grid grid, int i)
        {
            
            var button = CreateSheetButton(style.SecondaryButtonStyle, _additionalButtons[i]);

            button.Clicked += (sender, e) =>
            {
                Hide();
                ButtonTapped(this, new AlertSheetEventArgs(i + 1));
            };

            grid.Children.Add(button, 0, 3 + i);
        }
    }
}
