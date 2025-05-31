using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Settings;

namespace SaltStacker.Application.Interfaces
{
    public interface IApplicationService
    {
        void UpdateCache();

        string GetSetting(string key);

        ServiceResult SetSettings(string key, string value);

        Task<List<CountryApi>> GetCountriesApiAsync();

        Task<List<ProvinceApi>> GetProvincesApiAsync(int countryId);

        Task<List<CityApi>> GetCitiesApiAsync(int provinceId);

        Task<List<ZoneApi>> GetZonesApiAsync(int cityId);

        Task<List<ZoneApi>> GetZonesApiAsync();

        Task<List<ZoneApi>> GetZonesByKitchenAsync(int kitchenId);

        Task<List<ZoneDto>> GetZonesAsync();

        Task<ZoneDto> GetZoneAsync(int id);
    }
}
