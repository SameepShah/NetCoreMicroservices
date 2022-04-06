using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;
        public PlatformRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null){
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);

        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        /// <summary>
        /// Get Platforms by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(x=>x.Id == id);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}