using System;
using System.Collections.ObjectModel;

namespace PublicacionesApp.Models;

public enum PublicationType
{
    Libro_Completo,
    Capitulo,
    Articulo_Revista,
    Congreso
}

public enum PublicationStatus
{
    En_Revision,
    Aceptado,
    Rechazado
}

public class Publication
{
    public string Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public PublicationType Type { get; set; }
    public PublicationStatus Status { get; set; }
    public ObservableCollection<string> Authors { get; set; } = new();

    public Publication() { }

    public Publication(
        string id,
        string title,
        DateTime date,
        PublicationType type,
        PublicationStatus status,
        params string[] authors)
    {
        Id = id;
        Title = title;
        Date = date;
        Type = type;
        Status = status;
        foreach (var a in authors)
            Authors.Add(a);
    }
}
