using PublicacionesApp.Views;

namespace PublicacionesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // ruta para detalle, coincide con el parámetro "pubId" que pasamos
            Routing.RegisterRoute("publicationDetail", typeof(PublicationDetailPage));
        }
    }
}
