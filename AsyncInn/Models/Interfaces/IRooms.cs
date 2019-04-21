using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRooms
    {
        // C
        Task CreateRooms(Rooms room);

        // R
        bool RoomsExists(int id);

        Task<Rooms> GetRooms(int id);

        Task<List<Rooms>> GetRooms();

        // U
        Task UpdateRoom(int id, Rooms room);

        // D
        Task DeleteRoom(int id);

        Task DeleteConfirm(int id);
    }
}
