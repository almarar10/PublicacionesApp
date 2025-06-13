using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class AddAuthorViewModel : BaseViewModel
{
    readonly IPublicationService _service;

    private Publication? _selectedPublication;
    private string _newAuthor = string.Empty;

    public ObservableCollection<Publication> Publications { get; } = new();

    public Publication? SelectedPublication
    {
        get => _selectedPublication;
        set => SetProperty(ref _selectedPublication, value);
    }

    public string NewAuthor
    {
        get => _newAuthor;
        set => SetProperty(ref _newAuthor, value);
    }

    public ICommand AddAuthorCommand { get; }

    public AddAuthorViewModel(IPublicationService service)
    {
        _service = service;
        Title = "Reemplazar autor";

        AddAuthorCommand = new Command(async () => await OnAddAsync());

        LoadPublications();
    }

    public void LoadPublications()
    {
        Publications.Clear();
        foreach (var pub in _service.GetAll())
            Publications.Add(pub);
    }

    private async Task OnAddAsync()
    {
        if (IsBusy)
            return;

        if (SelectedPublication == null || string.IsNullOrWhiteSpace(NewAuthor))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Debes seleccionar una publicación y escribir el nombre del autor.",
                "OK");
            return;
        }

        IsBusy = true;
        try
        {
            SelectedPublication.Authors.Clear();

            SelectedPublication.Authors.Add(NewAuthor.Trim());

            _service.Update(SelectedPublication);

            await Application.Current.MainPage.DisplayAlert(
                "Éxito",
                $"Autor existente reemplazado por '{NewAuthor.Trim()}' en '{SelectedPublication.Title}'.",
                "OK");

            NewAuthor = string.Empty;

            await Shell.Current.GoToAsync("..");
        }
        catch (System.Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                ex.Message,
                "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
