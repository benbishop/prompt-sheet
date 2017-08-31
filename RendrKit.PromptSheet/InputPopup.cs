using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
    public class InputPopup : PromptSheetViewBase
    {
		private Label _titleLabel;
		private Label _messageLabel;
		private Entry _input;
		
		private TaskCompletionSource<InputResult> _result;

		readonly InputPopupStyle style;

		readonly string _title;
		readonly string _message;
		readonly InputOptions _inputOptions;
		readonly string[] _buttons;

        public InputPopup(string title, string message, InputOptions inputOptions, string[] buttons, InputPopupStyle style) : base(style)
        {
            _title = title;
            _message = message;
            _inputOptions = inputOptions;
            _buttons = buttons;

            this.style = style;
        }

        protected override View CreateContent()
        {
			var grid = new Grid()
			{
				BackgroundColor = Color.Transparent,
				Padding = new Thickness(5, 20, 5, 5),
				RowDefinitions = new RowDefinitionCollection()
				{
					new RowDefinition() {Height=new GridLength(1, GridUnitType.Auto)},
					new RowDefinition() {Height=new GridLength(1, GridUnitType.Auto)},
				}
			};

			for (int i = 0; i < _buttons.Length; i++)
			{
				grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
			}

			_titleLabel = CreateLabel(style.TitleLabelStyle, _title);

			_messageLabel = CreateLabel(style.BodyLabelStyle, _message);

            _input = CreateEntry(style.EntryStyle, _inputOptions);			

			_input.Completed += (sender, e) =>
			{
				Finish();
			};

			for (int i = 0; i < _buttons.Length; i++)
			{
                SheetButton button = null;

                if (i == 0)
                {
                    button = CreateSheetButton(style.PrimaryButtonStyle, _buttons[0]);
                }
                else
                {
                    button = CreateSheetButton(style.SecondaryButtonStyle, _buttons[i]);
                }
				
				button.Clicked += (sender, e) =>
				{
					Hide();
					var senderText = (sender as Button).Text;
					_result.TrySetResult(new InputResult() { ButtonIndex = _buttons.ToList().IndexOf(senderText) , InputText = _input.Text });
				};
				grid.Children.Add(button, 0, 3 + i);
			}

			grid.Children.Add(_titleLabel, 0, 0);
			grid.Children.Add(_messageLabel, 0, 1);
			grid.Children.Add(_input, 0, 2);

			return grid;
        }

		private void Finish()
		{
			this.Animate("Hiding", new Animation((x) =>
			{
				AbsoluteLayout.SetLayoutBounds(PopupContent, new Rectangle(0, 1 + x, 1, AbsoluteLayout.AutoSize));
				Overlay.Opacity = 0.55 - (0.55 * x);
			}), finished: (rate, finished) =>
			{
				var parentAbsolute = this.Parent as AbsoluteLayout;
				parentAbsolute.Children.Remove(this);
				
				_result.TrySetResult(new InputResult() { ButtonIndex = 0, InputText = _input.Text });
			});
		}

		public new Task<InputResult> Show()
		{
			this.Animate("Showing", new Animation((x) =>
			{
				AbsoluteLayout.SetLayoutBounds(PopupContent, new Rectangle(0, 2 - x, 1, AbsoluteLayout.AutoSize));
				Overlay.Opacity = x * 0.55;
			}), finished: (arg1, arg2) =>
			{
				_input.Focus();
			});

			_result = new TaskCompletionSource<InputResult>();
			return _result.Task;
		}
    }
}
