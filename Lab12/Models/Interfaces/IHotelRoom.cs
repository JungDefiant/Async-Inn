using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom room, int hotelID);

        Task<List<HotelRoom>> GetRooms(int hotelID);

        Task<HotelRoom> GetRoom(int roomNumber, int hotelID);

        Task<HotelRoom> Update(HotelRoom room);

        Task Delete(int roomNumber, int hotelID);
    }
}
