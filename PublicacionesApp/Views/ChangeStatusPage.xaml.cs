using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class ChangeStatusPage : ContentPage
{
    public ChangeStatusPage(ChangeStatusViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
