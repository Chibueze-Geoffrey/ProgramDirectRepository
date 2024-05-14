using System.ComponentModel.DataAnnotations;

namespace ProgramDirect.Common.DTOs.Request
{
    public class CreateProgramRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<CreateQuestionRequest> Questions { get; set; }
    }
}
