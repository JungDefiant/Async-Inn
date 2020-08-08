using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns></returns>
        Task<Amenity> Create(Amenity amenity);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Amenity>> GetAmenities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Amenity> GetAmenity(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns></returns>
        Task<Amenity> Update(Amenity amenity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
