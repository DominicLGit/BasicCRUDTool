using System;
using System.Windows.Input;

namespace BasicCRUDTool
{
    class RelayParameterizedCommand : ICommand
    {

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        private Action<object> mAction;

        public RelayParameterizedCommand(Action<object> action)
        {
            this.mAction = action;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
} 
