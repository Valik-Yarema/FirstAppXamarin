using AppXamarin.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppXamarin.ViewModels
{
    public class IncreaseLikeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private NewPostViewModel postViewModel;

        public IncreaseLikeCommand(NewPostViewModel vm)
        {
            postViewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return postViewModel != null;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                postViewModel.IncreaseLike();
        }
    }
}
