using Microsoft.Maui.Controls;
using PublicacionesApp.ViewModels;

namespace PublicacionesApp.Views;

public partial class AddPublicationPage : ContentPage
{
	public AddPublicationPage(AddPublicationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}