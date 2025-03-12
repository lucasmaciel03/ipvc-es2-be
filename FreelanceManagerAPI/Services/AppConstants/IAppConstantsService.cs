using FreelanceManagerAPI.IO.Constants;

namespace FreelanceManagerAPI.Services.AppConstants
{
    public interface IAppConstantsService
    {
        Task<AppConstantsDto> GetAppConstantsAsync(string userId);
    }
}
