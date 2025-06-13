using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.Services;

namespace PublicacionesApp.ViewModels;

public class AddPublicationViewModel : BaseViewModel
{
    readonly IPublicationService _service;

    
    private string _id = string.Empty;
    private string _title = string.Empty;
    private DateTime _date = DateTime.Today;
    private PublicationType _selectedType;
    private PublicationStatus _selectedStatus;
    private string _authorsText = string.Empty;

    
    public string Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public DateTime Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }

    public PublicationType SelectedType
    {
        get => _selectedType;
        set => SetProperty(ref _selectedType, value);
    }

    public PublicationStatus SelectedStatus
    {
        get => _selectedStatus;
        set => SetProperty(ref _selectedStatus, value);
    }

    public Array Types => Enum.GetValues(typeof(PublicationType));
    public Array Statuses => Enum.GetValues(typeof(PublicationStatus));

    public string AuthorsText
    {
        get => _authorsText;
        set => SetProperty(ref _authorsText, value);
    }

    public ICommand SaveCommand { get; }

    public AddPublicationViewModel(IPublicationService service)
    {
        _service = service;
        Title = "Nueva publicación";
        SaveCommand = new Command(async () => await OnSaveAsync());
    }

    private async System.Threading.Tasks.Task OnSaveAsync()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        try
        {
            if (string.IsNullOrWhiteSpace(Id) ||
                string.IsNullOrWhiteSpace(Title) ||
                string.IsNullOrWhiteSpace(AuthorsText))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe rellenar Id, Título y Autores.",
                    "OK");
                return;
            }
            var authors = AuthorsText
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            var publication = new Publication(
                Id,
                Title,
                Date,
                SelectedType,
                SelectedStatus,
                authors);

            _service.Add(publication);

            await Application.Current.MainPage.DisplayAlert(
                "Éxito",
                "Publicación añadida correctamente.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
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
