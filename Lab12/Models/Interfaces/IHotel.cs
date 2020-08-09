using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        Task<HotelDTO> Create(HotelDTO hotel);

        Task<List<HotelDTO>> GetHotels();

        Task<HotelDTO> GetHotel(int id);

        Task<HotelDTO> Update(HotelDTO hotel);

        Task Delete(int id);

        Task AddRoom(int hotelID, int layoutID, decimal price);

        Task RemoveRoom(int hotelID, int roomNumber);
    }
}
