using System.Collections.ObjectModel;
using System.Windows.Input;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class PublicationsListViewModel : BaseViewModel
{
    private readonly IPublicationService _service;

    public ObservableCollection<Publication> Publicaciones { get; } = new();

    public ICommand RefreshCommand { get; }
    public ICommand ItemTappedCommand { get; }

    public PublicationsListViewModel(IPublicationService service)
    {
        Title = "Publicaciones";
        _service = service;

        RefreshCommand = new Command(LoadPublications);
        ItemTappedCommand = new Command<Publication>(OnItemTapped);
        LoadPublications();
    }

    private void LoadPublications()
    {
        Publicaciones.Clear();
        foreach (var pub in _service.GetAll())
            Publicaciones.Add(pub);
    }

    private async void OnItemTapped(Publication pub)
    {
        if (pub == null)
            return;

        bool aceptar = await Shell.Current.DisplayAlert(
            "Ver detalles",
            $"¿Ver detalles de '{pub.Title}'?",
            "Sí", "No");

        if (aceptar)
            await Shell.Current.GoToAsync($"publicationDetail?pubId={pub.Id}");
    }
}
