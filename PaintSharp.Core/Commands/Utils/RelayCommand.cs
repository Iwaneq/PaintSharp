using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintSharp.Core.Commands.Utils
{
    public class RelayCommand : ICommand
    {
        readonly Action _execute;
        readonly Predicate<object> _canExecute;

        #region Constructor / Setup

        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new NullReferenceException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute) : this (execute, null)
        {

        }

        #endregion

        #region Command

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke();
        } 

        #endregion
    }
}
