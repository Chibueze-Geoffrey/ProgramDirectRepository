namespace ProgramDirect.Domain.Entities
{
    public class ApplicationQuestionAnswer : BaseEntity
    {
        public string Answer { get; set; }
        public Guid ApplicationQuestionId { get; set; }
        public Guid ApplicationId { get; set; }

        public ApplicationQuestion ApplicationQuestion { get; set; }
    }
}
