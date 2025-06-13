using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class SearchByAuthorPage : ContentPage
{
    public SearchByAuthorPage(SearchByAuthorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
