using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class FilterByTypePage : ContentPage
{
    public FilterByTypePage(FilterByTypeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
