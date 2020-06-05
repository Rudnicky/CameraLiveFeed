using System.Threading.Tasks;
using System.Windows.Input;

namespace CameraLiveFeed.Core.Services.RelayCommand
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
