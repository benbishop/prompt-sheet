using System;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
    public class InputPopupStyle : SheetViewStyle
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

		public SheetEntryStyle EntryStyle
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

		public InputPopupStyle()
		{
			TitleLabelStyle = new SheetLabelStyle();
			BodyLabelStyle = new SheetLabelStyle();
            EntryStyle = new SheetEntryStyle();
			PrimaryButtonStyle = new SheetButtonStyle();
			SecondaryButtonStyle = new SheetButtonStyle();
		}

		static InputPopupStyle _default;
		public static InputPopupStyle Default
		{
			get
			{
				if (_default == null)
					_default = new InputPopupStyle()
					{
						Padding = new Thickness(5, 20, 5, 5),
						BackgroundEndColor = BackgroundEndColorDefault,
						BackgroundStartColor = BackgroundStartColorDefault,
						OverlayColor = OverlayColorDefault,
						OverlayOpacity = OverlayOpacityDefault,

						TitleLabelStyle = SheetLabelStyle.TitleLabelDefault,
						BodyLabelStyle = SheetLabelStyle.BodyLabelDefault,
						PrimaryButtonStyle = SheetButtonStyle.PrimaryButtonDefault,
						SecondaryButtonStyle = SheetButtonStyle.SecondaryButtonDefault,
                        EntryStyle = SheetEntryStyle.EntryDefault

					};

				return _default;

			}
		}
    }
}
