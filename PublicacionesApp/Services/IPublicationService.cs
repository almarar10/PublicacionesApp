using System.Collections.Generic;
using PublicacionesApp.Models;

namespace PublicacionesApp.Services;

public interface IPublicationService
{
    IEnumerable<Publication> GetAll();
    Publication? FindById(string id);
    IEnumerable<Publication> FindByTitle(string title);
    IEnumerable<Publication> FindByAuthor(string author);
    IEnumerable<Publication> FindByType(PublicationType type);
    void Add(Publication publication);
    void Update(Publication publication);
    void Delete(string id);
    void AddAuthor(string publicationId, string author);
}
