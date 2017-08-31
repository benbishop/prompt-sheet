using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ObjCRuntime;
using RendrKit.PromptSheet.iOS;

namespace BetterForms.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

            PromptSheetiOS.Init();

            return base.FinishedLaunching(app, options);


        }
    }
}

