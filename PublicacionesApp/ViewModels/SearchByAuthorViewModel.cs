using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class SearchByAuthorViewModel : BaseViewModel
{
    readonly IPublicationService _service;

    private string _authorQuery = string.Empty;
    public string AuthorQuery
    {
        get => _authorQuery;
        set => SetProperty(ref _authorQuery, value);
    }

    public ObservableCollection<Publication> AuthorResults { get; } = new();

    public ICommand SearchCommand { get; }

    public SearchByAuthorViewModel(IPublicationService service)
    {
        _service = service;
        Title = "Buscar por autor";
        SearchCommand = new Command(ExecuteSearch);
    }

    void ExecuteSearch()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(AuthorQuery))
            return;

        IsBusy = true;
        AuthorResults.Clear();

        var results = _service.FindByAuthor(AuthorQuery.Trim());
        foreach (var pub in results)
            AuthorResults.Add(pub);

        IsBusy = false;
    }
}
