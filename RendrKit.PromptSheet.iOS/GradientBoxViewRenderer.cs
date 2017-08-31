using System;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RendrKit.PromptSheet.GradientBoxView), typeof(RendrKit.PromptSheet.iOS.GradientBoxViewRenderer))]
namespace RendrKit.PromptSheet.iOS
{
	public class GradientBoxViewRenderer : VisualElementRenderer<GradientBoxView>
	{
		private CAGradientLayer GradientLayer
		{
			get { return (CAGradientLayer)Layer; }
		}

		public GradientBoxViewRenderer()
		{
			GradientLayer.StartPoint = new CGPoint(0.5, 0);
			GradientLayer.EndPoint = new CGPoint(0.5, 1);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<GradientBoxView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				Update();
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == GradientBoxView.ColorsProperty.PropertyName)
			{
				Update();
			}
		}

		private void Update()
		{
			if (Element == null)
				return;

			var colors = Element.Colors;

			if (colors == null)
			{
				colors = new Xamarin.Forms.Color[] { Element.BackgroundColor, Element.BackgroundColor };
			}
			else if (colors.Count() == 1)
			{
				colors = new Xamarin.Forms.Color[] { colors.First(), colors.First() };
			}

			GradientLayer.Colors = colors.Select(s => s.ToCGColor()).ToArray();


			Layer.MasksToBounds = true;
		}

		[Export("layerClass")]
		public static Class LayerClass()
		{
			return new Class(typeof(CAGradientLayer));
		}
	}
}
