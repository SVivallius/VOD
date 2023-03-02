namespace VOD.common.Services
{
    public interface IAdminService
    {
        Task<List<TDto>> GetAsync<TDto>(string uri);
    }
}