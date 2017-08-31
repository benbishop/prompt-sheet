using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RendrKit.PromptSheet
{
	public class GradientBoxView : ContentView
	{

		

		public static readonly BindableProperty ColorsProperty =
            BindableProperty.Create("Colors",typeof(Color[]),typeof(Color[]), new Color[]{Color.Blue, Color.Blue});

		public Color[] Colors
		{
			get { return (Color[])GetValue(ColorsProperty); }
			set { SetValue(ColorsProperty, value); }
		}

		private static void OnColorsChanged(BindableObject bindable, Color[] oldvalue, Color[] newValue)
		{
			var view = (GradientBoxView)bindable;
			view.Colors = newValue as Color[];
		}

		public Task<bool> ColorsTo(Color[] newColors, uint length = 250, Easing easing = null, uint rate = 16)
		{
			if (easing == null)
			{
				easing = Easing.Linear;
			}

			TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();
			WeakReference<GradientBoxView> weakReference = new WeakReference<GradientBoxView>(this);
			var colors = this.Colors.ToList();

			(new Animation((Double f) =>
			{
				GradientBoxView visualElement;
				if (weakReference.TryGetTarget(out visualElement))
				{
					visualElement.Colors = NewColor(colors.ToArray(), newColors, f);
				}
			}, 0, 1, easing, null)).Commit(this, "ColorsTo", rate, length, null, (Double f, Boolean a) => taskCompletionSource.SetResult(a), null);
			return taskCompletionSource.Task;
		}

		private Color[] NewColor(Color[] sourceColors, Color[] targetColors, double x)
		{
			var newColors = new List<Color>();

			for (int i = 0; i < Math.Min(sourceColors.Count(), targetColors.Count()); i++)
			{
				newColors.Add(NewColor(sourceColors[i], targetColors[i], x));
			}

			return newColors.ToArray();
		}

		private Color NewColor(Color sourceColor, Color targetColor, double x)
		{
			var red = sourceColor.R + (x * (targetColor.R - sourceColor.R));
			var green = sourceColor.G + (x * (targetColor.G - sourceColor.G));
			var blue = sourceColor.B + (x * (targetColor.B - sourceColor.B));
			var alpha = sourceColor.A + (x * (targetColor.A - sourceColor.A));
			return Color.FromRgba(red, green, blue, alpha);
		}
	}
}
