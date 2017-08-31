using System;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
    public class SheetEntryStyle
    {
        public SheetEntryStyle()
        {
            HeightRequest = -1;
        }

		public Color BackgroundColor
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

		public double HeightRequest
		{
			get;
			set;
		}

        internal void ApplyTo(Entry entry)
        {
            entry.BackgroundColor = BackgroundColor;
            entry.FontAttributes = FontAttributes;
            entry.FontSize = FontSize;
            entry.FontFamily = FontFamily;
            entry.TextColor = TextColor;
            entry.Margin = Margin;
            entry.HeightRequest = HeightRequest;
        }

		public static SheetEntryStyle EntryDefault = new SheetEntryStyle()
        {
            FontSize = 19,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromRgb(85, 84, 84),
            Margin = new Thickness(10, 20, 10, 5),
            HeightRequest = 40
		};
    }
}
