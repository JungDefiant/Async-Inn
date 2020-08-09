using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> Create(HotelRoomDTO room, int hotelID);

        Task<List<HotelRoomDTO>> GetRooms(int hotelID);

        Task<HotelRoomDTO> GetRoom(int roomNumber, int hotelID);

        Task<HotelRoomDTO> Update(HotelRoomDTO room);

        Task Delete(int roomNumber, int hotelID);
    }
}
