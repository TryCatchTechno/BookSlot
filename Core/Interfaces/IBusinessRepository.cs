using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBusinessRepository
    {
        Task<Business> GetBusinessByIdAsync(int id); 
        Task <IReadOnlyList<Business>> GetBusinessesAsync();
        Task <IReadOnlyList<BusinessCategory>> GetBusinessesCategoriesAsync();
    }
}