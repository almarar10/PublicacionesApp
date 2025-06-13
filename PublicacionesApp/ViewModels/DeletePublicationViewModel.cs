using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class DeletePublicationViewModel : BaseViewModel
{
    readonly IPublicationService _service;

    private string _titleQuery = string.Empty;
    private Publication? _foundPublication;

    public string TitleQuery
    {
        get => _titleQuery;
        set => SetProperty(ref _titleQuery, value);
    }

    public Publication? FoundPublication
    {
        get => _foundPublication;
        set => SetProperty(ref _foundPublication, value);
    }

    public ICommand SearchCommand { get; }
    public ICommand DeleteCommand { get; }

    public DeletePublicationViewModel(IPublicationService service)
    {
        _service = service;
        Title = "Eliminar publicación";

        SearchCommand = new Command(ExecuteSearch);
        DeleteCommand = new Command(async () => await ExecuteDeleteAsync());
    }

    void ExecuteSearch()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(TitleQuery))
            return;

        IsBusy = true;
        FoundPublication = _service
            .FindByTitle(TitleQuery.Trim())
            .FirstOrDefault();
        IsBusy = false;

        if (FoundPublication == null)
            Application.Current.MainPage.DisplayAlert(
                "No encontrado",
                $"No se encontró publicación «{TitleQuery}».",
                "OK");
    }

    async System.Threading.Tasks.Task ExecuteDeleteAsync()
    {
        if (FoundPublication == null)
            return;

        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Confirmar eliminación",
            $"¿Eliminar publicación '{FoundPublication.Title}'?",
            "Sí", "No");
        if (!confirm)
            return;

        try
        {
            _service.Delete(FoundPublication.Id);
            await Application.Current.MainPage.DisplayAlert(
                "Éxito",
                "Publicación eliminada correctamente.",
                "OK");

            FoundPublication = null;
            TitleQuery = string.Empty;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                ex.Message,
                "OK");
        }
    }
}
