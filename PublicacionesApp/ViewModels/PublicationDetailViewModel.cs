using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels
{
    [QueryProperty(nameof(PubId), "pubId")]
    public class PublicationDetailViewModel : BaseViewModel
    {
        readonly IPublicationService _service;
        private Publication? _publication;
        private string _pubId = string.Empty;

        public string PubId
        {
            get => _pubId;
            set
            {
                if (SetProperty(ref _pubId, value))
                    LoadPublication();
            }
        }

        public string PublicationTitle => _publication?.Title ?? string.Empty;
        public string PublicationDate => _publication?.Date.ToString("d") ?? string.Empty;
        public string PublicationType => _publication?.Type.ToString() ?? string.Empty;
        public string PublicationStatus => _publication?.Status.ToString() ?? string.Empty;
        public ObservableCollection<string> Authors
            => _publication?.Authors ?? new ObservableCollection<string>();

        public PublicationDetailViewModel(IPublicationService service)
        {
            _service = service;
            Title = "Detalle publicación";
        }

        private async void LoadPublication()
        {
            if (string.IsNullOrWhiteSpace(PubId))
                return;

            _publication = _service.FindById(PubId);

            if (_publication == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"No se encontró la publicación con Id '{PubId}'.",
                    "OK");
                return;
            }

            OnPropertyChanged(nameof(PublicationTitle));
            OnPropertyChanged(nameof(PublicationDate));
            OnPropertyChanged(nameof(PublicationType));
            OnPropertyChanged(nameof(PublicationStatus));
            OnPropertyChanged(nameof(Authors));
        }
    }
}
