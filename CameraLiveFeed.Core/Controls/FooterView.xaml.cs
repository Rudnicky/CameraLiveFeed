using System.Windows;
using System.Windows.Controls;

namespace CameraLiveFeed.Core.Controls
{
    /// <summary>
    /// Interaction logic for FooterView.xaml
    /// </summary>
    public partial class FooterView : UserControl
    {
        public string Version
        {
            get { return (string)GetValue(VersionProperty); }
            set { SetValue(VersionProperty, value); }
        }
        public static readonly DependencyProperty VersionProperty =
            DependencyProperty.Register("Version", typeof(string), typeof(FooterView), new PropertyMetadata(string.Empty));

        public string Copyright
        {
            get { return (string)GetValue(CopyrightProperty); }
            set { SetValue(CopyrightProperty, value); }
        }
        public static readonly DependencyProperty CopyrightProperty =
            DependencyProperty.Register("Copyright", typeof(string), typeof(FooterView), new PropertyMetadata(string.Empty));

        public string PoweredBy
        {
            get { return (string)GetValue(PoweredByProperty); }
            set { SetValue(PoweredByProperty, value); }
        }
        public static readonly DependencyProperty PoweredByProperty =
            DependencyProperty.Register("PoweredBy", typeof(string), typeof(FooterView), new PropertyMetadata(string.Empty));

        public FooterView()
        {
            InitializeComponent();
        }
    }
}
