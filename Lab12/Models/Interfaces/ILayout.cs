using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface ILayout
    {
        Task<RoomLayout> Create(RoomLayout layout);

        Task<List<RoomLayout>> GetLayouts();

        Task<RoomLayout> GetLayout(int id);

        Task<RoomLayout> Update(RoomLayout layout);

        Task Delete(int id);

        Task AddAmenityToRoom(int layoutID, int amenityID);

        Task RemoveAmenityToRoom(int layoutID, int amenityID);
    }
}
