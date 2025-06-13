using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class AddAuthorPage : ContentPage
{
    readonly AddAuthorViewModel _vm;

    public AddAuthorPage(AddAuthorViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.LoadPublications();
    }
}
