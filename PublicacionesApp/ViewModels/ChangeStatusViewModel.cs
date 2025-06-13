using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class ChangeStatusViewModel : BaseViewModel
{
    readonly IPublicationService _service;

    private string _searchQuery = string.Empty;
    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }

    private Publication? _foundPublication;
    public Publication? FoundPublication
    {
        get => _foundPublication;
        set => SetProperty(ref _foundPublication, value);
    }

    private PublicationStatus _newStatus;
    public PublicationStatus NewStatus
    {
        get => _newStatus;
        set => SetProperty(ref _newStatus, value);
    }

    public Array Statuses => Enum.GetValues(typeof(PublicationStatus));

    public ICommand SearchCommand { get; }
    public ICommand ChangeStatusCommand { get; }

    public ChangeStatusViewModel(IPublicationService service)
    {
        _service = service;
        Title = "Cambiar estado";

        NewStatus = (PublicationStatus)Statuses.GetValue(0)!;

        SearchCommand = new Command(ExecuteSearch);
        ChangeStatusCommand = new Command(ExecuteChangeStatus);
    }

    void ExecuteSearch()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(SearchQuery))
            return;

        IsBusy = true;
        FoundPublication = _service.FindById(SearchQuery)
                           ?? _service.FindByTitle(SearchQuery).FirstOrDefault();
        IsBusy = false;

        if (FoundPublication == null)
            Application.Current.MainPage.DisplayAlert("No encontrado",
                $"No se encontró publicación «{SearchQuery}».", "OK");
        else
            NewStatus = FoundPublication.Status;
    }

    async void ExecuteChangeStatus()
    {
        if (FoundPublication == null)
            return;

        if (FoundPublication.Status == NewStatus)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Info", "El estado seleccionado es el mismo que el actual.", "OK");
            return;
        }

        FoundPublication.Status = NewStatus;
        _service.Update(FoundPublication);

        await Application.Current.MainPage.DisplayAlert(
            "Éxito",
            $"Estado de «{FoundPublication.Title}» actualizado a {NewStatus}.",
            "OK");
    }
}
