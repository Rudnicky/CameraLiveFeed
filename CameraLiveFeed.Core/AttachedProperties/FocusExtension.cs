using System.Windows;

namespace CameraLiveFeed.Core.AttachedProperties
{
    public static class FocusExtension
    {
        public static DependencyProperty IsFocusedProperty = DependencyProperty
            .RegisterAttached("IsFocused", typeof(bool),
            typeof(FocusExtension),
            new UIPropertyMetadata(false, OnIsFocusedChanged));

        public static bool GetIsFocused(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsFocusedProperty, value);
        }

        public static void OnIsFocusedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            FrameworkElement textBox = dependencyObject as FrameworkElement;
            bool newValue = (bool)dependencyPropertyChangedEventArgs.NewValue;
            bool oldValue = (bool)dependencyPropertyChangedEventArgs.OldValue;
            if (newValue && !oldValue && !textBox.IsFocused)
            {
                textBox.Focus();
            }

        }
    }
}
