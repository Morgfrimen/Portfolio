using System;
using System.Threading.Tasks;
using System.Windows.Input;
using QuadraticEquation;
using WpfApp.ViewModels;

namespace WpfApp.Command.DiscriminantPage
{
    public sealed class RunDiscriminant : ICommand
    {
        private Task<string> _runTask;

        public bool CanExecute(object parameter)
        {
            if (_runTask == default) return true;
            if (_runTask.Status == TaskStatus.Running) return false;

            return _runTask.IsCompleted;
        }

        public async void Execute(object parameter)
        {
#pragma warning disable 8625

            // ReSharper disable once AssignNullToNotNullAttribute
            this.CanExecuteChanged.Invoke(sender: parameter, e: default);
#pragma warning restore 8625

            if (parameter is not DiscriminantViewModels) throw new ArgumentNullException(paramName: nameof(DiscriminantViewModels));
            DiscriminantViewModels discriminantViewModels = (DiscriminantViewModels) parameter;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (discriminantViewModels.Result != default) discriminantViewModels.C -= discriminantViewModels.Result;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (discriminantViewModels.A != default && discriminantViewModels.B != default && discriminantViewModels.C != default)
                _runTask = Task.Run
                (
                    function: () => FullQuadraticEquation.FullQuadraticEquationReqcord(a: discriminantViewModels.A, b: discriminantViewModels.B, c: discriminantViewModels.C)
                        .ToString()
                );

            else
                _runTask = Task.Run
                (
                    function: () => IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord
                            (a: discriminantViewModels.A, b: discriminantViewModels.B, c: discriminantViewModels.C)
                        .ToString()
                );
            discriminantViewModels.ResultRun = _runTask.Result;
            this.CanExecuteChanged.Invoke(sender: parameter, e: default);
        }

        public event EventHandler CanExecuteChanged;
    }
}