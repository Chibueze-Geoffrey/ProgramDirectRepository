using ProgramDirect.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProgramDirect.Common.DTOs.Request
{
    public class UpdateQuestionRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public ApplicationQuestionType Type { get; set; }
        public List<string> Options { get; set; }
        public int MaximumChoices { get; set; }
        public int MinimumChoices { get; set; }
    }
}
