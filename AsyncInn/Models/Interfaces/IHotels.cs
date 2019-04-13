using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotels
    {
        // C
        Task CreateHotels(Hotels hotel);

        // R
        bool HotelsExists(int id);

        Task<Hotels> GetHotel(int id);

        Task<IEnumerable<Hotels>> GetHotels();

        // U
        Task UpdateHotels(int id, Hotels hotel);

        // D
        Task DeleteHotels(int id);
    }
}
