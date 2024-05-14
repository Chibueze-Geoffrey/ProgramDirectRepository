using Microsoft.AspNetCore.Mvc;
using ProgramDirect.Application.Interfaces;
using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;

namespace ProgramDirect.API.Controllers
{
    public class ProgramsController : BaseController
    {
        private readonly IProgramService _programService;

        public ProgramsController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddProgram(CreateProgramRequest request)
            => CustomResponse(await _programService.AddProgram(request));

        [HttpPut("questions/{id}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdateQuestion([FromRoute] Guid id, [FromBody] UpdateQuestionRequest request)
        {
            request.Id = id;
            return CustomResponse(await _programService.EditQuestion(request));
        }

        [HttpGet("questions/{programId}")]
        [ProducesResponseType(typeof(ApiResponse<List<QuestionResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> GetQuestions(Guid programId)
            => CustomResponse(await _programService.GetQuestions(programId));
    }
}
