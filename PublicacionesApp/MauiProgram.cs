using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;

using PublicacionesApp;
using PublicacionesApp.Services;
using PublicacionesApp.ViewModels;
using PublicacionesApp.Views;

namespace PublicacionesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // ============================================
            //  PublicacionesApp MAUI Program – Menú
            // ============================================
            // 1. App & Fonts
            // 2. Servicios
            // 3. ViewModels & Páginas
            //    3.1 Listado de Publicaciones
            //    3.2 Detalle de Publicación
            //    3.3 Añadir Publicación
            //    3.4 Añadir Autor
            //    3.5 Filtrar por Tipo
            //    3.6 Buscar por Autor
            //    3.7 Cambiar Estado
            //    3.8 Eliminar Publicación

            // 1. App & Fonts
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Orbitron-Regular.ttf", "Orbitron");
                });

            // 2. Servicios (IoC)
            builder.Services.AddSingleton<IPublicationService, PublicationService>();

            // 3. ViewModels & Páginas

            // 3.1 Listado de Publicaciones
            builder.Services.AddTransient<PublicationsListViewModel>();
            builder.Services.AddTransient<PublicationsListPage>();

            // 3.2 Detalle de Publicación
            builder.Services.AddTransient<PublicationDetailViewModel>();
            builder.Services.AddTransient<PublicationDetailPage>();

            // 3.3 Añadir Publicación
            builder.Services.AddTransient<AddPublicationViewModel>();
            builder.Services.AddTransient<AddPublicationPage>();

            // 3.4 Añadir Autor
            builder.Services.AddTransient<AddAuthorViewModel>();
            builder.Services.AddTransient<AddAuthorPage>();

            // 3.5 Filtrar por Tipo
            builder.Services.AddTransient<FilterByTypeViewModel>();
            builder.Services.AddTransient<FilterByTypePage>();

            // 3.6 Buscar por Autor
            builder.Services.AddTransient<SearchByAuthorViewModel>();
            builder.Services.AddTransient<SearchByAuthorPage>();

            // 3.7 Cambiar Estado
            builder.Services.AddTransient<ChangeStatusViewModel>();
            builder.Services.AddTransient<ChangeStatusPage>();

            // 3.8 Eliminar Publicación
            builder.Services.AddTransient<DeletePublicationViewModel>();
            builder.Services.AddTransient<DeletePublicationPage>();

            return builder.Build();
        }
    }
}
