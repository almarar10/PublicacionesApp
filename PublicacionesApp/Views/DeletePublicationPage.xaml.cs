using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class DeletePublicationPage : ContentPage
{
    public DeletePublicationPage(DeletePublicationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
