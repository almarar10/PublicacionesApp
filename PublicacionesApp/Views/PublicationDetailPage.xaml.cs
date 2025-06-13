using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class PublicationDetailPage : ContentPage
{
    public PublicationDetailPage(PublicationDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
