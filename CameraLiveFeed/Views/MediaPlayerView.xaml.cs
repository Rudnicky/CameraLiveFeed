using CameraLiveFeed.ViewModels;
using System.Windows.Controls;

namespace CameraLiveFeed.Views
{
    /// <summary>
    /// Interaction logic for MediaPlayerView.xaml
    /// </summary>
    public partial class MediaPlayerView : UserControl
    {
        public MediaPlayerView()
        {
            InitializeComponent();

            InitializeDataContext();
        }

        private void InitializeDataContext()
        {
            this.DataContext = new MediaPlayerViewModel();
        }
    }
}
