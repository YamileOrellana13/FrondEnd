﻿using ListView.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ListView.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ListView.ViewModels
{
    class PaisesViewModel : BaseViewModel
    {
        #region Services

        private ApiService apiService;
        #endregion


        #region Attributes

        private ObservableCollection<Paises> paises;            //aqui dejo paises con minuscula
        private bool isRefreshing;
        #endregion


        #region Properties
        public ObservableCollection<Paises> Paises              //aqui dejo paises con mayuscula
        {
            get { return this.paises; }
            set { SetValue(ref this.paises, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion



        #region Constructors

        public PaisesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPaises();
        }

        #endregion


        #region Methods
        private async void LoadPaises()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                   "Error", connection.Message,
                   "Aceptar");
                return;
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            var response = await this.apiService.GetList<Paises>(
                "https://restcountries.eu/",                                //AQUI CAMBIAMOS  POR EL ENLACE QUE NOS DE//"/api","/Students"); esto es para el profe
                "/rest",
                "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", response.Message,
                    "Aceptar");
                return;
            }
            var list = (List<Paises>)response.Result;
            this.Paises = new ObservableCollection<Paises>(list);
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPaises);

            }
        }
        #endregion
    }
}
