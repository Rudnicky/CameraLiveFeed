using System;
using System.Windows;
using System.Windows.Input;

namespace CameraLiveFeed.Core.Behaviors
{
    public class GotFocusBehaviour
    {
        public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.RegisterAttached("GotFocusCommand",
           typeof(ICommand), typeof(GotFocusBehaviour),
           new FrameworkPropertyMetadata(new PropertyChangedCallback(GotFocusCommandChanged)));

        private static void GotFocusCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.GotFocus += new RoutedEventHandler(Element_GotFocus);
        }

        private static void Element_GotFocus(object sender, EventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand command = GetFocusCommand(element);
            command.Execute(e);
        }

        public static void SetGotFocusCommand(UIElement element, ICommand value)
        {
            element.SetValue(GotFocusCommandProperty, value);
        }

        public static ICommand GetFocusCommand(UIElement element)
        {
            return (ICommand)element.GetValue(GotFocusCommandProperty);
        }
    }
}
