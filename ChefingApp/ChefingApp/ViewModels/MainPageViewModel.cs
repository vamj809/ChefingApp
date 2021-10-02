﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefingApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _title;
        
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public MainPageViewModel(INavigationService navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
        }

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("");
        }
            
    }
}