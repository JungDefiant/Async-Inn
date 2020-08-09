using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns></returns>
        Task<AmenityDTO> Create(AmenityDTO amenity);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AmenityDTO>> GetAmenities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmenityDTO> GetAmenity(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns></returns>
        Task<AmenityDTO> Update(AmenityDTO amenity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
