using AutoMapper;
using Newtonsoft.Json;
using ProgramDirect.Application.Interfaces;
using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;
using ProgramDirect.Common.Enums;
using ProgramDirect.Domain.Entities;

namespace ProgramDirect.Application.Implementations
{
    public class ProgramService : IProgramService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgramService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddProgram(CreateProgramRequest request)
        {
            try
            {
                var program = new OrganisationProgram
                {
                    Title = request.Title,
                    Description = request.Description,
                };
                var questions = new List<ApplicationQuestion>();

                foreach(var questionRequest in request.Questions)
                {
                    var question = new ApplicationQuestion
                    {
                        Question = questionRequest.Question,
                        Type = questionRequest.Type,
                        OrganisationProgramId = program.Id
                    };

                    if(questionRequest.Type == ApplicationQuestionType.Dropdown)
                    {
                        if (questionRequest.Options == null) return ApiResponse.Response("Please provide options for the dropdown", ApiResponseCode.BadRequest);
                        question.Options = JsonConvert.SerializeObject(questionRequest.Options);
                    }

                    if (questionRequest.Type == ApplicationQuestionType.MultipleChoice)
                    {
                        if (questionRequest.Options == null) return ApiResponse.Response("Please provide options for the multiple choice question", ApiResponseCode.BadRequest);
                        question.Options = JsonConvert.SerializeObject(questionRequest.Options);
                        question.MaximumChoices = questionRequest.MaximumChoices;
                        question.MinimumChoices = questionRequest.MinimumChoices;
                    }

                    if (questionRequest.Type == ApplicationQuestionType.YesNo)
                    {
                        question.Options = JsonConvert.SerializeObject(new List<string> { "Yes", "No"});
                    }

                    questions.Add(question);
                }

                _unitOfWork.Repository<OrganisationProgram>().Add(program);
                _unitOfWork.Repository<ApplicationQuestion>().AddRange(questions);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.Response("Success", ApiResponseCode.Ok);
            }
            catch (Exception)
            {
                //log
                return ApiResponse.Response("Something went wrong", ApiResponseCode.ProcessingError);
            }
        }

        public async Task<ApiResponse> EditQuestion(UpdateQuestionRequest request)
        {
            try
            {
                var question = await _unitOfWork.Repository<ApplicationQuestion>().GetAsync(q => q.Id == request.Id);
                if (question == null) return ApiResponse.Response("Could not find question", ApiResponseCode.BadRequest);

                question.Question = request.Question;
                question.Type = request.Type;

                if (question.Type == ApplicationQuestionType.Dropdown)
                {
                    if(request.Options == null) return ApiResponse.Response("Please provide options for the dropdown", ApiResponseCode.BadRequest);
                    question.Options = JsonConvert.SerializeObject(request.Options);
                }

                if (question.Type == ApplicationQuestionType.MultipleChoice)
                {
                    if (request.Options == null) return ApiResponse.Response("Please provide options for the multiple choice question", ApiResponseCode.BadRequest);
                    question.Options = JsonConvert.SerializeObject(request.Options);

                    if(request.MinimumChoices < 1 ||  request.MaximumChoices < 1) 
                        return ApiResponse.Response("Minimum and maximum number of choices must be greater than or equal to 1", ApiResponseCode.BadRequest);
                    question.MaximumChoices = request.MaximumChoices;
                    question.MinimumChoices = request.MinimumChoices;
                }

                if (question.Type == ApplicationQuestionType.YesNo)
                {
                    question.Options = JsonConvert.SerializeObject(new List<string> { "Yes", "No" });
                }

                _unitOfWork.Repository<ApplicationQuestion>().Update(question);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.Response("Success", ApiResponseCode.Ok);
            }
            catch (Exception)
            {
                //log
                return ApiResponse.Response("Something went wrong", ApiResponseCode.ProcessingError);
            }
        }

        public async Task<ApiResponse<List<QuestionResponse>>> GetQuestions(Guid programId)
        {
            var questions = await _unitOfWork.Repository<ApplicationQuestion>().GetAllAsync(q => q.OrganisationProgramId == programId);
            var response = _mapper.Map<List<QuestionResponse>>(questions);

            return ApiResponse<List<QuestionResponse>>.Response(response, "Success", ApiResponseCode.Ok);
        }
    }
}
