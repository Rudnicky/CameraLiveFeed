using System.Windows;
using System.Windows.Input;

namespace CameraLiveFeed.Core.Behaviors
{
    public class MouseBehaviour
    {
        #region MouseUp
        public static readonly DependencyProperty MouseUpCommandProperty = DependencyProperty.RegisterAttached("MouseUpCommand",
            typeof(ICommand), typeof(MouseBehaviour),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseUpCommandChanged)));

        private static void MouseUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseUp += new MouseButtonEventHandler(Element_MouseUp);
        }

        static void Element_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand command = GetMouseUpCommand(element);
            command.Execute(e);
        }

        public static void SetMouseUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseUpCommandProperty, value);
        }

        public static ICommand GetMouseUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseUpCommandProperty);
        }
        #endregion

        #region MouseDown
        public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.RegisterAttached("MouseDownCommand",
            typeof(ICommand), typeof(MouseBehaviour),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseDownCommandChanged)));

        private static void MouseDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseDown += new MouseButtonEventHandler(Element_MouseDown);
        }

        static void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand command = GetMouseDownCommand(element);
            command.Execute(e);
        }

        public static void SetMouseDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseDownCommandProperty, value);
        }

        public static ICommand GetMouseDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseDownCommandProperty);
        }
        #endregion
    }
}
