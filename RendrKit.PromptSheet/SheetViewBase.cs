using System;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
	public abstract class SheetViewBase : ScrollView
	{
		protected View PopupContent;
		protected BoxView Overlay;
		protected AbsoluteLayout SheetLayout;

        readonly SheetViewStyle style;

        protected SheetViewBase(SheetViewStyle style)
		{
            this.style = style;
            SheetLayout = new AbsoluteLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Overlay = new BoxView()
			{
                BackgroundColor = style.OverlayColor,
				Color = style.OverlayColor,
				Opacity = 0
			};

			SheetLayout.Children.Add(Overlay, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

			Content = SheetLayout;
		}

		protected abstract View CreateContent();

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			if (width != -1 && height != -1 && PopupContent == null)
			{
				PopupContent = new GradientBoxView()
				{
                    
					Content = CreateContent(),
                    Colors = new Color[] { style.BackgroundEndColor, style.BackgroundStartColor }
				};
				SheetLayout.Children.Add(PopupContent, new Rectangle(0, 2, this.Width, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.YProportional | AbsoluteLayoutFlags.WidthProportional);
			}
		}



		public void Show()
		{
			this.Animate("Showing", new Animation((x) =>
			{
				AbsoluteLayout.SetLayoutBounds(PopupContent, new Rectangle(0, 2 - x, 1, AbsoluteLayout.AutoSize));
                Overlay.Opacity = x * style.OverlayOpacity;
			}));
		}

		public void Hide()
		{
			this.Animate("Hiding", new Animation((x) =>
			{
				AbsoluteLayout.SetLayoutBounds(PopupContent, new Rectangle(0, 1 + x, 1, AbsoluteLayout.AutoSize));
				Overlay.Opacity = style.OverlayOpacity - (style.OverlayOpacity * x);
			}), finished: (rate, finished) =>
			{
				var parentAbsolute = this.Parent as AbsoluteLayout;
				parentAbsolute.Children.Remove(this);
			});
		}
	}
}
