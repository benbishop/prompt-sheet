using System;
using Xamarin.Forms;
namespace RendrKit.PromptSheet
{
    public class SheetLabelStyle
    {



        public double FontSize
        {
            get;
            set;
        }

        public string FontFamily
        {
            get;
            set;
        }

        public FontAttributes FontAttributes
        {
            get;
            set;
        }

        public Color TextColor
        {
            get;
            set;
        }

        public TextAlignment Alignment
        {
            get;
            set;
        }

        public Thickness Margin{
            get;
            set;
        }

        public SheetLabelStyle()
        {

        }

        public void ApplyTo(Label label)
        {
            label.FontSize = FontSize;
            label.FontFamily = FontFamily;
            label.FontAttributes = FontAttributes;
            label.TextColor = TextColor;
            label.HorizontalTextAlignment = Alignment;
            label.Margin = Margin;
        }

        public static SheetLabelStyle TitleLabelDefault = new SheetLabelStyle()
        {
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.White,
            Alignment = TextAlignment.Center
        };

        public static SheetLabelStyle BodyLabelDefault = new SheetLabelStyle()
        {
            FontSize = 18,
            FontAttributes = FontAttributes.None,
            TextColor = Color.White,
            Alignment = TextAlignment.Center,
            Margin = new Thickness(20, 10, 20, 0)
        };
    }
}
