using Microsoft.AspNetCore.Mvc;
using ProgramDirect.Application.Interfaces;
using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;

namespace ProgramDirect.API.Controllers
{
    public class ApplicationsController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddApplication(CreateApplicationRequest request)
            => CustomResponse(await _applicationService.AddApplication(request));
    }
}
