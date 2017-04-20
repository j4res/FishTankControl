﻿using FishTankControl.Helpers;
using FishTankControl.Models;
using FishTankControl.Services;

using Xamarin.Forms;

namespace FishTankControl.ViewModels
{
    public class BaseMisAcuariosViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Acuario> DataStore => DependencyService.Get<IDataStore<Acuario>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

