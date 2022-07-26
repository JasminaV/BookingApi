
using BookingApi.Models;

namespace BookingApi.Interfaces;
public interface IResourceService
{   
    Task<IEnumerable<Resource>> GetAllResources();
}