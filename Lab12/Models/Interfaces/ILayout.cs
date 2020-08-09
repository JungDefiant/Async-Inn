using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface ILayout
    {
        Task<LayoutDTO> Create(LayoutDTO layout);

        Task<List<LayoutDTO>> GetLayouts();

        Task<LayoutDTO> GetLayout(int id);

        Task<LayoutDTO> Update(LayoutDTO layout);

        Task Delete(int id);

        Task AddAmenityToRoom(int layoutID, int amenityID);

        Task RemoveAmenityFromRoom(int layoutID, int amenityID);
    }
}
