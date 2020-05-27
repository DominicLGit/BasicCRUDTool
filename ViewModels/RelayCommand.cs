using System;
using System.Windows.Input;

namespace BasicCRUDTool
{
    class RelayCommand : ICommand
    {

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        private readonly Action mAction;

        public RelayCommand(Action action)
        {
            this.mAction = action;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
} 
