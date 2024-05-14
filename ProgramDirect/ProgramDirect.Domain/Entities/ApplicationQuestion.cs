using ProgramDirect.Common.Enums;

namespace ProgramDirect.Domain.Entities
{
    public class ApplicationQuestion : BaseEntity
    {
        public string Question { get; set; }
        public ApplicationQuestionType Type { get; set; }
        public string? Options { get; set; }
        public int MaximumChoices { get; set; }
        public int MinimumChoices { get; set; }
        public Guid OrganisationProgramId { get; set; }

        public OrganisationProgram OrganisationProgram { get; set; }
    }
}
