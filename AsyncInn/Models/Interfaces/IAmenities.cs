using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
        // C
        Task CreateAmenitie(Amenities amenities);

        // R
        bool AmenitiesExists(int id);

        Task<Amenities> GetAmenitie(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        // U
        Task UpdateAmenitie(int id, Amenities amenities);

        // D
        Task DeleteAmenitie(int id);
    }
}
