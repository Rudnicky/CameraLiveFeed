using CameraLiveFeed.Core.Models;
using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.ViewModels.Base;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CameraLiveFeed.ViewModels
{
    public class LeftPanelViewModel : BaseViewModel
    {
        private IEnumerable<Option> _options;
        public IEnumerable<Option> Options
        {
            get => _options;
            set => SetProperty(ref _options, value);
        }

        public LeftPanelViewModel(ILogger logger, IRegionManager regionManager) 
            : base(logger, regionManager)
        {
            InitializeOptions();
        }

        private void InitializeOptions()
        {
            _options = new List<Option>
            {
                new Option { Title = "Cameras", Image = (ImageSource)Application.Current.Resources["CameraImage"] },
                new Option { Title = "Snapshots", Image = (ImageSource)Application.Current.Resources["SnapshotImage"] },
                new Option { Title = "Settings", Image = (ImageSource)Application.Current.Resources["SettingsImage"] }
            };
        }
    }
}
