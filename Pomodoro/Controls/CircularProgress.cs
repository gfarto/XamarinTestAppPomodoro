using System;
using Xamarin.Forms;

namespace Pomodoro.Controls
{
    public class CircularProgress : View
    {
        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create("Progress", typeof(float), typeof(CircularProgress), (float)0);

        public float Progress
        {
            get
            {
                return (float)GetValue(CircularProgress.ProgressProperty);
            }
            set
            {
                SetValue(CircularProgress.ProgressProperty, value);
            }
        }

        public static readonly BindableProperty MaxProperty =
            BindableProperty.Create("Max", typeof(float), typeof(CircularProgress), (float)0);

        public float Max
        {
            get
            {
                return (float)GetValue(CircularProgress.MaxProperty);
            }
            set
            {
                SetValue(CircularProgress.MaxProperty, value);
            }
        }

        public static readonly BindableProperty IndeterminateProperty =
            BindableProperty.Create(nameof(Indeterminate), typeof(bool), typeof(CircularProgress), default(bool));

        public bool Indeterminate
        {
            get
            {
                return (bool)GetValue(IndeterminateProperty);
            }
            set
            {
                SetValue(IndeterminateProperty, value);
            }
        }

        public static readonly BindableProperty IndeterminateSpeedProperty =
            BindableProperty.Create("IndeterminateSpeed", typeof(int), typeof(CircularProgress), (int)10);

        public int IndeterminateSpeed
        {
            get { return (int)GetValue(CircularProgress.IndeterminateSpeedProperty); }
            set { SetValue(CircularProgress.IndeterminateSpeedProperty, value); }
        }

        public static readonly BindableProperty ProgressBackgroundColorProperty =
            BindableProperty.Create("ProgressBackgroundColor", typeof(Color), typeof(CircularProgress), Color.White);

        public Color ProgressBackgroundColor
        {
            get { return (Color)GetValue(CircularProgress.ProgressBackgroundColorProperty); }
            set { SetValue(CircularProgress.ProgressBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create("ProgressColor", typeof(Color), typeof(CircularProgress), Color.White);

        public Color ProgressColor
        {
            get { return (Color)GetValue(CircularProgress.ProgressColorProperty); }
            set { SetValue(CircularProgress.ProgressColorProperty, value); }
        }

        public CircularProgress()
        {
        }
    }
}
