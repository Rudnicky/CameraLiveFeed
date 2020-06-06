using CameraLiveFeed.Core.Services.RelayCommand.Base;
using System;
using System.Threading.Tasks;

namespace CameraLiveFeed.Core.Services.RelayCommand
{
    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<Task> _command;
        private readonly Func<bool> _canExecute;

        public AsyncCommand(Func<Task> command, Func<bool> canExecute)
        {
            _command = command;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _command();
        }
    }

    public class AsyncCommand<T> : AsyncCommandBase
    {
        private readonly Func<T, Task> _command;
        private readonly Func<bool> _canExecute;

        public AsyncCommand(Func<T, Task> command, Func<bool> canExecute)
        {
            _command = command;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _command.Invoke((T)parameter);
        }
    }
}
