using AutoMapper;
using Newtonsoft.Json;
using ProgramDirect.Application.Interfaces;
using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;
using ProgramDirect.Common.Enums;
using ProgramDirect.Domain.Entities;

namespace ProgramDirect.Application.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddApplication(CreateApplicationRequest request)
        {
            try
            {
                var program = await _unitOfWork.Repository<OrganisationProgram>().GetAsync(p => p.Id == request.OrganisationProgramId);
                if (program == null) return ApiResponse.Response($"Program not found", ApiResponseCode.BadRequest);

                var application = _mapper.Map<ProgramApplication>(request);
                var questions = await _unitOfWork.Repository<ApplicationQuestion>().GetAllAsync(q => q.OrganisationProgramId == request.OrganisationProgramId);
                var answers = new List<ApplicationQuestionAnswer>();

                foreach(var question in questions)
                {
                    if(request.QuestionAnswers.Count(a => a.ApplicationQuestionId == question.Id) != 1)
                        return ApiResponse.Response($"{question.Question} - is required", ApiResponseCode.BadRequest);
                }

                foreach(var answer in request.QuestionAnswers)
                {
                    var question = questions.First(q => q.Id == answer.ApplicationQuestionId);
                    if(question.Type == ApplicationQuestionType.YesNo)
                    {
                        if(!JsonConvert.DeserializeObject<List<string>>(question.Options).Contains(answer.Answer.First()))
                            return ApiResponse.Response($"Wrong answer provided", ApiResponseCode.BadRequest);
                    }

                    if (question.Type == ApplicationQuestionType.Dropdown)
                    {
                        if (!JsonConvert.DeserializeObject<List<string>>(question.Options).Contains(answer.Answer.First()))
                            return ApiResponse.Response($"Wrong answer provided", ApiResponseCode.BadRequest);
                    }

                    if (question.Type == ApplicationQuestionType.MultipleChoice)
                    {
                        if (answer.Answer.Any(a => !JsonConvert.DeserializeObject<List<string>>(question.Options).Contains(a)))
                            return ApiResponse.Response($"Wrong option provided", ApiResponseCode.BadRequest);
                        if(answer.Answer.Count < question.MinimumChoices)
                            return ApiResponse.Response($"You must provide at least {question.MinimumChoices} answers for {question.Question}", ApiResponseCode.BadRequest);
                        if(answer.Answer.Count > question.MaximumChoices)
                            return ApiResponse.Response($"You must provide a maximum of {question.MaximumChoices} answers for {question.Question}", ApiResponseCode.BadRequest);
                    }

                    var questionAnswer = new ApplicationQuestionAnswer
                    {
                        ApplicationQuestionId = answer.ApplicationQuestionId,
                        ApplicationId = application.Id,
                        Answer = JsonConvert.SerializeObject(answer.Answer)
                    };

                    answers.Add(questionAnswer);
                }

                _unitOfWork.Repository<ProgramApplication>().Add(application);
                _unitOfWork.Repository<ApplicationQuestionAnswer>().AddRange(answers);

                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.Response("Success", ApiResponseCode.Ok);
            }
            catch (Exception)
            {
                //log
                return ApiResponse.Response("Something went wrong", ApiResponseCode.ProcessingError);
            }
        }
    }
}
