using System;
using Xamarin.Forms;
namespace RendrKit.PromptSheet
{
    public class SheetViewStyle
    {
        public static Color BackgroundEndColorDefault = Color.FromRgb(3, 111, 170);
        public static Color BackgroundStartColorDefault = Color.FromRgb(0, 165, 255);
        public static Color OverlayColorDefault = Color.Black;
        public static float OverlayOpacityDefault = .55f;


        public Color BackgroundEndColor
        {
            get;
            set;
        }

		public Color BackgroundStartColor
		{
			get;
			set;
		}

		public Color OverlayColor
		{
			get;
			set;
		}

        public float OverlayOpacity{
            get;
            set;
        }

        public SheetViewStyle()
        {
        }
    }
}
