using ProgramDirect.Common.Enums;

namespace ProgramDirect.Common.DTOs.Response
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Question { get; set; }
        public ApplicationQuestionType Type { get; set; }
        public List<string> Options { get; set; }
        public int MaximumChoices { get; set; }
        public int MinimumChoices { get; set; }
        public Guid OrganisationProgramId { get; set; }
    }
}
