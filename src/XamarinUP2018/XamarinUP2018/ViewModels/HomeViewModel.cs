using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinUP2018.ViewModels
{
    public sealed class HomeViewModel : BindableBase
    {
        private string text;
        private readonly PageDialogService pageDialogService;

        public string Text {
            get => text;
            set => SetProperty(ref text, value);
        }

        public ICommand ShowAlert { get; }

        public HomeViewModel(PageDialogService pageDialogService)
        {
            this.pageDialogService = pageDialogService;

            ShowAlert = new DelegateCommand(async () => await ExecuteShowAllert());
        }

        private Task ExecuteShowAllert() 
            => pageDialogService.DisplayAlertAsync("Hello", "The Message", "Ok");

    }
}
