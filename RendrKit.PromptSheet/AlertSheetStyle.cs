using System;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
    public class AlertSheetStyle : SheetViewStyle
    {
        public SheetLabelStyle TitleLabelStyle
        {
            get;
            set;
        }

        public SheetLabelStyle BodyLabelStyle
        {
            get;
            set;
        }

        public SheetButtonStyle PrimaryButtonStyle
        {
            get;
            set;
        }

        public SheetButtonStyle SecondaryButtonStyle
        {
            get;
            set;
        }

        public Thickness Padding
        {
            get;
            set;
        }

        public AlertSheetStyle()
        {
            TitleLabelStyle = new SheetLabelStyle();
            BodyLabelStyle = new SheetLabelStyle();
            PrimaryButtonStyle = new SheetButtonStyle();
            SecondaryButtonStyle = new SheetButtonStyle();
        }

        static AlertSheetStyle _default;
        public static AlertSheetStyle Default
        {
            get
            {
                if (_default == null)
                    _default = new AlertSheetStyle()
                    {
                        Padding = new Thickness(5, 20, 5, 5),
                        BackgroundEndColor = BackgroundEndColorDefault,
                        BackgroundStartColor = BackgroundStartColorDefault,
                        OverlayColor = OverlayColorDefault,
                        OverlayOpacity = OverlayOpacityDefault,

                        TitleLabelStyle = SheetLabelStyle.TitleLabelDefault,
                        BodyLabelStyle = SheetLabelStyle.BodyLabelDefault,
                        PrimaryButtonStyle = SheetButtonStyle.PrimaryButtonDefault,
                        SecondaryButtonStyle = SheetButtonStyle.SecondaryButtonDefault


                    };

                return _default;

            }
        }
    }
}
