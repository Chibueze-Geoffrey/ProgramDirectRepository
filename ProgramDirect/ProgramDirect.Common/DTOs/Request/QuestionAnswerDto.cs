namespace ProgramDirect.Common.DTOs.Request
{
    public class QuestionAnswerDto
    {
        public List<string> Answer { get; set; }
        public Guid ApplicationQuestionId { get; set; }
    }
}
