using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BetterForms.ViewModels;
using XLabs.Forms.Validation;
using System.Diagnostics;
using RendrKit.PromptSheet;

namespace BetterForms.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage ()
        {
            var vm = new LoginViewModel ();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert ("Sorry", "The credentials you supplied are incorrect.", "Ok");
            InitializeComponent ();

            EmailEntry.Completed += (object sender, EventArgs e) => {
                PasswordEntry.Focus ();
            };

            PasswordEntry.Completed += (object sender, EventArgs e) => {
                vm.SubmitCommand.Execute (null);
            };

            LoginButton.Clicked += async (sender, e) => {
                var buttonIndex = await PromptSheet.ShowAlert(this.PageContainer, "Oops", "Sorry, the supplied credentials are incorrect. Do you want to try again?", "Yes", new string[]{"No", "Maybe"});
                Debug.WriteLine($"Button with index {buttonIndex} tapped");

                if (buttonIndex == 1)
                {
                    var inputResult = await PromptSheet.ShowInputPopup(this.PageContainer, "We can help!", "May we can send you an email to reset your password.", new InputOptions() { Placeholder = "Your Email" }, new string[] { "Yes, Sent it!", "No, thanks" });
                    Debug.WriteLine($"Button with index {inputResult.ButtonIndex} tapped");
                    Debug.WriteLine($"Input with content {inputResult.InputText}");
                }
            };
        }
    }
}

