using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);

        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int id);

        Task<Hotel> Update(int id, Hotel hotel);

        Task Delete(int id);
    }
}
