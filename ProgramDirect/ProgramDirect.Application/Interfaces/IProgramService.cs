using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;

namespace ProgramDirect.Application.Interfaces
{
    public interface IProgramService
    {
        Task<ApiResponse> AddProgram(CreateProgramRequest request);
        Task<ApiResponse> EditQuestion(UpdateQuestionRequest request);
        Task<ApiResponse<List<QuestionResponse>>> GetQuestions(Guid programId);
    }
}
