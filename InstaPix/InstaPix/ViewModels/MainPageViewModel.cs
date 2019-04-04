using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaPix.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
            set { SetProperty(ref _displayText, value); }
        }

        public DelegateCommand EnterNameCommand => new DelegateCommand(async () => await OnSubmit());

        private async Task OnSubmit()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                DisplayText = $"Hello {Name}, welcome to 10 Days of Xamarin";
            }
            else
            {
                await DialogService.DisplayAlertAsync("Error!", "Name is required.", "Ok");
            }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "10 Days of Xamarin: Day 1";
            DisplayText = "Hello stranger, welcome to 10 Days of Xamarin";
        }
    }
}
