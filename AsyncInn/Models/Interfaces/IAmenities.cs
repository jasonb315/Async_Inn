using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
        Task CreateAmenitie(Amenities amenities);

        bool AmenitiesExists(int id);

        Task<Amenities> GetAmenitie(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        Task UpdateAmenitie(int id, Amenities amenities);

        Task DeleteAmenitie(int id);
    }
}
