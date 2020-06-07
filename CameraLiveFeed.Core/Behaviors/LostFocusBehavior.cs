using System;
using System.Windows;
using System.Windows.Input;

namespace CameraLiveFeed.Core.Behaviors
{
    public class LostFocusBehaviour
    {
        public static readonly DependencyProperty LostFocusCommandProperty = DependencyProperty.RegisterAttached("LostFocusCommand",
           typeof(ICommand), typeof(LostFocusBehaviour),
           new FrameworkPropertyMetadata(new PropertyChangedCallback(LostFocusCommandChanged)));

        private static void LostFocusCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.LostFocus += new RoutedEventHandler(Element_LostFocus);
        }

        private static void Element_LostFocus(object sender, EventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand command = GetLostFocusCommand(element);
            command.Execute(e);
        }

        public static void SetLostFocusCommand(UIElement element, ICommand value)
        {
            element.SetValue(LostFocusCommandProperty, value);
        }

        public static ICommand GetLostFocusCommand(UIElement element)
        {
            return (ICommand)element.GetValue(LostFocusCommandProperty);
        }
    }
}
