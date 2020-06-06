using System.Windows;
using System.Windows.Controls;

namespace CameraLiveFeed.Core.Behaviors
{
    public class PasswordBoxWatermark : DependencyObject
    {
        public static readonly DependencyProperty PasswordLengthProperty =
            DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxWatermark),
                new UIPropertyMetadata(0));

        public static readonly DependencyProperty IsWatermarkProperty =
            DependencyProperty.RegisterAttached("IsWatermark", typeof(bool), typeof(PasswordBoxWatermark),
                new UIPropertyMetadata(false, OnIsWatermarkChanged));

        private static void OnIsWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            if (passwordBox == null)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
            else
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                SetPasswordLength(passwordBox, passwordBox.Password.Length);
            }
        }

        public static bool GetIsWatermark(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsWatermarkProperty);
        }

        public static void SetIsWatermark(DependencyObject obj, bool value)
        {
            obj.SetValue(IsWatermarkProperty, value);
        }

        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }
    }
}
