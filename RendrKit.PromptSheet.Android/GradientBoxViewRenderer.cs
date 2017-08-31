using System;
using RendrKit.PromptSheet;
using RendrKit.PromptSheet.Android;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using Android.Graphics;
using System.Linq;

[assembly: ExportRenderer(typeof(GradientBoxView), typeof(GradientBoxViewRenderer))]
namespace RendrKit.PromptSheet.Android
{
	public class GradientBoxViewRenderer : VisualElementRenderer<GradientBoxView>
	{
		private GradientDrawable _drawable;

		protected override void OnElementChanged(ElementChangedEventArgs<GradientBoxView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				_drawable = new GradientDrawable();
				_drawable.SetOrientation(GradientDrawable.Orientation.TopBottom);

				this.SetBackground(_drawable);
			}

			UpdateColors();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
            
			//this.SetLayerType(Android.Views.LayerType.Hardware, null);
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == GradientBoxView.BackgroundColorProperty.PropertyName)
			{
				UpdateColors();
			}
			else if (e.PropertyName == GradientBoxView.ColorsProperty.PropertyName)
			{
				UpdateColors();
			}
			//else if (e.PropertyName == GradientBoxView.CornerRadiusProperty.PropertyName)
			//{
			//  UpdateCornerRadius();
			//}

			//this.SetLayerType(Android.Views.LayerType.None, null);
		}

		private void UpdateColors()
		{
			if (_drawable == null)
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

			_drawable.SetColors(colors.Select(s => s.ToAndroid().ToArgb()).ToArray());
		}

		private float GetRadius(double radius)
		{
			radius = (float)Math.Round(Width * radius / 260);

			if (radius <= 0)
			{
				radius = 0;
			}

			return (float)radius;
		}

		//private void UpdateCornerRadius()
		//{
		//  if (_drawable == null)
		//      return;

		//  var topLeft = GetRadius(Element.CornerRadius.Left);
		//  var topRight = GetRadius(Element.CornerRadius.Top);
		//  var bottomRight = GetRadius(Element.CornerRadius.Right);
		//  var bottomLeft = GetRadius(Element.CornerRadius.Bottom);

		//  _drawable.SetCornerRadii(new float[] { topLeft, topLeft, topRight, topRight, bottomRight, bottomRight, bottomLeft, bottomLeft });
		//}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			//UpdateCornerRadius();
		}

		//        protected override void OnDraw(Canvas canvas)
		//        {
		//            Paint paint = new Paint();
		//            paint.AntiAlias = true;
		//
		//            RectF rect = new RectF(0.0f, 0.0f, Width, Height);
		//            canvas.DrawRoundRect(rect, 20, 20, paint);
		//
		//            base.OnDraw(canvas);
		//        }
	}
}
