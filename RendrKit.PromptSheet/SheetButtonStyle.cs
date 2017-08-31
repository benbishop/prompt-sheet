using System;
using Xamarin.Forms;
namespace RendrKit.PromptSheet
{
    public class SheetButtonStyle
    {

        public Color BackgroundColor
        {
            get;
            set;
        }

        public Color BorderColor
        {
            get;
            set;
        }

        public double BorderWidth
        {
            get;
            set;
        }

		public int BorderRadius
		{
			get;
			set;
		}

        public FontAttributes FontAttributes
        {
            get;
            set;
        }

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

        public TextAlignment TextAlignment
        {
            get;
            set;
        }

        public Color TextColor
        {
            get;
            set;
        }

        public Thickness Margin
        {
            get;
            set;
        }

        public SheetButtonStyle()
        {




        }

        internal void ApplyTo(SheetButton button)
        {
            button.BackgroundColor = BackgroundColor;
            button.BorderColor = BorderColor;
            button.BorderWidth = BorderWidth;
            button.BorderRadius = BorderRadius;
            button.FontAttributes = FontAttributes;
            button.FontSize = FontSize;
            button.FontFamily = FontFamily;
            button.TextAlignment = TextAlignment;
            button.TextColor = TextColor;
            button.Margin = Margin;
        }

        public static SheetButtonStyle PrimaryButtonDefault = new SheetButtonStyle()
        {
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            TextAlignment = TextAlignment.Center,
            BackgroundColor = Color.White,
            BorderWidth = 1,
            BorderColor = Color.White,
            BorderRadius = 6,
            TextColor = Color.FromRgb(0, 165, 255),
            Margin = new Thickness(10, 30, 10, 10)
        };

        public static SheetButtonStyle SecondaryButtonDefault = new SheetButtonStyle()
        {
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            TextAlignment = TextAlignment.Center,
            BackgroundColor = Color.Transparent,
            BorderWidth = 2,
            BorderColor = Color.White,
            BorderRadius = 6,
            TextColor = Color.White,
            Margin = new Thickness(10, 0, 10, 10)
        };
    }
}
