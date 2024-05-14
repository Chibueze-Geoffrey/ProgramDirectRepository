using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;

namespace ProgramDirect.Application.Interfaces
{
    public interface IApplicationService
    {
        Task<ApiResponse> AddApplication(CreateApplicationRequest request);
    }
}
