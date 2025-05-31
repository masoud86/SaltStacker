using SaltStacker.Domain.Models.Setting;

namespace SaltStacker.Domain.Interfaces
{
    public interface IApplicationRepository
    {
        Task<List<ApplicationSetting>> GetApplicationSettingsAsync();

        Task SetApplicationSettingsAsync(ApplicationSetting model);

        void UpdateApplicationSettings(ApplicationSetting model);

        Task<List<Country>> GetActiveCountriesAsync();

        Task<List<Province>> GetActiveProvincesAsync(int countryId);

        Task<List<City>> GetActiveCitiesAsync(int provinceId);

        Task<List<Zone>> GetActiveZonesAsync(int cityId);

        Task<List<Zone>> GetActiveZonesAsync();

        Task<List<Zone>> GetZonesAsync();

        void UpdateZoneAsync(Zone model);

        Task<Zone> GetZoneAsync(int id);
    }
}
