using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class FilterByTypeViewModel : BaseViewModel
{
    readonly IPublicationService _service;

    private PublicationType _selectedType;
    public PublicationType SelectedType
    {
        get => _selectedType;
        set => SetProperty(ref _selectedType, value);
    }

    public Array Types => Enum.GetValues(typeof(PublicationType));

    public ObservableCollection<Publication> FilteredPublications { get; } = new();

    public ICommand FilterCommand { get; }

    public FilterByTypeViewModel(IPublicationService service)
    {
        _service = service;
        Title = "Filtrar publicaciones";
        SelectedType = (PublicationType)Types.GetValue(0)!;

        FilterCommand = new Command(LoadFiltered);
    }

    void LoadFiltered()
    {
        if (IsBusy) return;
        IsBusy = true;

        FilteredPublications.Clear();
        foreach (var pub in _service.FindByType(SelectedType))
            FilteredPublications.Add(pub);

        IsBusy = false;
    }
}
