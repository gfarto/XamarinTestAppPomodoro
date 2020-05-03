using Xamarin.Forms.Platform.Android;
using com.refractored.monodroidtoolkit;
using Pomodoro.Controls;
using Android.Content;
using System.ComponentModel;
using Xamarin.Forms;
using Pomodoro.Droid.Renderers;

[assembly: ExportRenderer(typeof(CircularProgress), typeof(CircularProgressRenderer))]
namespace Pomodoro.Droid.Renderers
{
    public class CircularProgressRenderer : ViewRenderer<CircularProgress, HoloCircularProgressBar>
    {
        public CircularProgressRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CircularProgress> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            var progress = new HoloCircularProgressBar(this.Context);
            progress.Max = this.Element.Max;
            progress.Indeterminate = this.Element.Indeterminate;
            progress.ProgressColor = this.Element.ProgressColor.ToAndroid();
            progress.ProgressBackgroundColor = this.Element.ProgressBackgroundColor.ToAndroid();
            progress.IndeterminateInterval = this.Element.IndeterminateSpeed;

            this.SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Control == null || this.Element == null)
                return;

            if (e.PropertyName == CircularProgress.MaxProperty.PropertyName)
                this.Control.Max = this.Element.Max;

            if (e.PropertyName == CircularProgress.IndeterminateProperty.PropertyName)
                this.Control.Indeterminate = this.Element.Indeterminate;

            if (e.PropertyName == CircularProgress.ProgressColorProperty.PropertyName)
                this.Control.ProgressColor = this.Element.ProgressColor.ToAndroid();

            if (e.PropertyName == CircularProgress.ProgressBackgroundColorProperty.PropertyName)
                this.Control.ProgressBackgroundColor = this.Element.ProgressBackgroundColor.ToAndroid();

            if (e.PropertyName == CircularProgress.IndeterminateSpeedProperty.PropertyName)
                this.Control.IndeterminateInterval = this.Element.IndeterminateSpeed;
        }
    }
}
