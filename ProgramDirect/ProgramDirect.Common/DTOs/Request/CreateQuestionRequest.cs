using ProgramDirect.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProgramDirect.Common.DTOs.Request
{
    public class CreateQuestionRequest
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public ApplicationQuestionType Type { get; set; }
        public List<string>? Options { get; set; }
        public int MaximumChoices { get; set; }
        public int MinimumChoices { get; set; }
    }
}
