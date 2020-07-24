using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom room);

        Task<List<HotelRoom>> GetRooms();

        Task<HotelRoom> GetRoom(int id);

        Task<HotelRoom> Update(HotelRoom room);

        Task Delete(int id);

        Task AddAmenityToRoom(int layoutID, int amenityID);

        Task RemoveAmenityFromRoom(int layoutID, int amenityID);
    }
}
