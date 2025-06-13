using System;
using System.Collections.Generic;
using System.Linq;
using PublicacionesApp.Models;

namespace PublicacionesApp.Services;

public class PublicationService : IPublicationService
{
    private static readonly List<Publication> _publications = new()
    {
        new Publication("PUB001", "Introducción a .NET MAUI", DateTime.Today.AddMonths(-2),
            PublicationType.Articulo_Revista, PublicationStatus.Aceptado,
            "Juan Pérez", "María López"),
        new Publication("PUB002", "Avances en IA", DateTime.Today.AddMonths(-1),
            PublicationType.Congreso, PublicationStatus.En_Revision,
            "Ana García"),
        new Publication("PUB003", "Desarrollo Móvil Multiplataforma", DateTime.Today,
            PublicationType.Libro_Completo, PublicationStatus.Aceptado,
            "Carlos Sánchez", "Lucía Fernández")
    };

    public IEnumerable<Publication> GetAll() =>
        _publications;

    public Publication? FindById(string id) =>
        _publications.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Publication> FindByTitle(string title) =>
        _publications.Where(p =>
            p.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Publication> FindByAuthor(string author) =>
        _publications.Where(p =>
            p.Authors.Any(a =>
                a.Contains(author, StringComparison.OrdinalIgnoreCase)));

    public IEnumerable<Publication> FindByType(PublicationType type) =>
        _publications.Where(p => p.Type == type);

    public void Add(Publication publication)
    {
        if (FindById(publication.Id) is not null)
            throw new ArgumentException($"Ya existe una publicación con Id '{publication.Id}'");
        _publications.Add(publication);
    }

    public void Update(Publication publication)
    {
        var existing = FindById(publication.Id)
            ?? throw new KeyNotFoundException($"No se encontró la publicación con Id '{publication.Id}'");

        existing.Title = publication.Title;
        existing.Date = publication.Date;
        existing.Type = publication.Type;
        existing.Status = publication.Status;
        existing.Authors = publication.Authors;
    }

    public void Delete(string id)
    {
        var existing = FindById(id)
            ?? throw new KeyNotFoundException($"No se encontró la publicación con Id '{id}'");
        _publications.Remove(existing);
    }

    public void AddAuthor(string publicationId, string author)
    {
        var pub = FindById(publicationId)
            ?? throw new KeyNotFoundException($"No se encontró la publicación con Id '{publicationId}'");
        if (!pub.Authors.Contains(author))
            pub.Authors.Add(author);
    }
}
