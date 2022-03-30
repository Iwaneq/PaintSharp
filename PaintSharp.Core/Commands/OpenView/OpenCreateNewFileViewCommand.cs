using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintSharp.Core.Commands.OpenView
{
    public class OpenCreateNewFileViewCommand : ICommand
    {
        private readonly IOpenWindowService _openWindowService;
        private readonly CreateNewFileViewModel _createNewFileViewModel;

        #region Constructor / Setup

        public OpenCreateNewFileViewCommand(IOpenWindowService openWindowService, CreateNewFileViewModel createNewFileViewModel)
        {
            _openWindowService = openWindowService;
            _createNewFileViewModel = createNewFileViewModel;
        }

        #endregion

        #region Command

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //Clear input fields in View, then open it
            _createNewFileViewModel.ResetViewModel();
            _openWindowService.OpenWindow("Create New File", _createNewFileViewModel, 350, 300);
        } 

        #endregion
    }
}
