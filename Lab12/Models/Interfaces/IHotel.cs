using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);

        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int id);

        Task<Hotel> Update(Hotel hotel);

        Task Delete(int id);

        Task AddRoom(int hotelID, int layoutID);

        Task RemoveRoom(int hotelID, int layoutID);
    }
}
