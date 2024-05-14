using AutoMapper;
using Newtonsoft.Json;
using ProgramDirect.Common.DTOs.Request;
using ProgramDirect.Common.DTOs.Response;
using ProgramDirect.Domain.Entities;

namespace ProgramDirect.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationQuestion, QuestionResponse>().ForMember(d => d.Options, opt => opt.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Options)));
            CreateMap<CreateApplicationRequest, ProgramApplication>();
        }
    }
}
