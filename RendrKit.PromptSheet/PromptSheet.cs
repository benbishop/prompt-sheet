using System;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace RendrKit.PromptSheet
{
    public static class PromptSheet
    {
        public static Task<int> ShowAlert(AbsoluteLayout targetContainer, string title, string body, string primaryButtonTitle = "Okay", string[] additionalButtons = null, AlertSheetStyle style = null)
        {            
            style = style ?? AlertSheetStyle.Default;

            additionalButtons = additionalButtons ?? new string[0];

            var tcs = new TaskCompletionSource<int>();

            var alertView = new AlertSheet(title, body, primaryButtonTitle, additionalButtons, style);

            targetContainer.Children.Add(alertView, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            alertView.Show();
            alertView.ButtonTapped += (sender, e) => tcs.TrySetResult((e as AlertSheetEventArgs).ButtonIndex);

            return tcs.Task;
        }

        public static Task<InputResult> ShowInputPopup(AbsoluteLayout targetContainer, string title, string body, InputOptions inputOptions, string[] buttons, InputPopupStyle style = null)
        {            
            style = style ?? InputPopupStyle.Default;

            var inputPopup = new InputPopup(title, body, inputOptions, buttons, style);

            targetContainer.Children.Add(inputPopup, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            return inputPopup.Show();
        }
    }
}
