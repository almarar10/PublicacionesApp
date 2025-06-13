using System.Linq;
using Microsoft.Maui.Controls;
using PublicacionesApp.Models;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class PublicationsListPage : ContentPage
{
    readonly PublicationsListViewModel _vm;

    public PublicationsListPage(PublicationsListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
        pubsCollection.SelectionChanged += OnSelectionChanged;
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Publication pub)
        {
            bool verDetalles = await DisplayAlert(
                "Ver detalles",
                $"¿Deseas ver más sobre “{pub.Title}”?",
                "Sí", "No");

            if (verDetalles)
            {
                await Shell.Current.GoToAsync($"publicationDetail?pubId={pub.Id}");
            }
        }

        ((CollectionView)sender).SelectedItem = null;
    }
}
