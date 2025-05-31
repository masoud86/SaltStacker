using Microsoft.EntityFrameworkCore;
using SaltStacker.Data.Context;
using SaltStacker.Domain.Interfaces;
using SaltStacker.Domain.Models.Setting;

namespace SaltStacker.Data.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationSetting>> GetApplicationSettingsAsync()
        {
            //Extra check to avoid error during create database (ReCaptcha configuration in SecurityServices class)
            if (_context != null && _context.Database.CanConnect())
            {
                return await _context.ApplicationSettings.ToListAsync();
            }
            return null;
        }

        public async Task SetApplicationSettingsAsync(ApplicationSetting model)
        {
            await _context.ApplicationSettings.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public void UpdateApplicationSettings(ApplicationSetting model)
        {
            _context.ApplicationSettings.Update(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<List<Country>> GetActiveCountriesAsync()
        {
            return await _context.Countries
                .Where(p => p.IsActive)
                .OrderBy(p => p.Title)
                .ToListAsync();
        }

        public async Task<List<Province>> GetActiveProvincesAsync(int countryId)
        {
            return await _context.Provinces
                .Where(p => p.CountryId == countryId && p.IsActive)
                .OrderBy(p => p.Title)
                .ToListAsync();
        }

        public async Task<List<City>> GetActiveCitiesAsync(int provinceId)
        {
            return await _context.Cities
                .Where(p => p.ProvinceId == provinceId && p.IsActive)
                .OrderBy(p => p.Title)
                .ToListAsync();
        }

        public async Task<List<Zone>> GetActiveZonesAsync(int cityId)
        {
            return await _context.Zones
                .Include(p => p.City)
                .Where(p => p.CityId == cityId && p.IsActive)
                .OrderBy(p => p.Title)
                .ToListAsync();
        }

        public async Task<List<Zone>> GetActiveZonesAsync()
        {
            return await _context.Zones
                .Include(p => p.City)
                .Where(p => p.IsActive)
                .OrderBy(p => p.City.Title)
                .ThenBy(p => p.Title)
                .ToListAsync();
        }

        public async Task<List<Zone>> GetZonesAsync()
        {
            return await _context.Zones
                .ToListAsync();
        }

        public void UpdateZoneAsync(Zone model)
        {
            var zone = _context.Zones.Find(model.Id);
            if (zone != null)
            {
                zone.EditDateTime = DateTime.UtcNow;
                _context.Zones.Update(zone);
                _context.Entry(zone).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public async Task<Zone> GetZoneAsync(int id)
        {
            return await _context.Zones.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
