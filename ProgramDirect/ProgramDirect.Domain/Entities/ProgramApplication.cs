using ProgramDirect.Common.Enums;

namespace ProgramDirect.Domain.Entities
{
    public class ProgramApplication : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string IdentificationNumber { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Guid OrganisationProgramId { get; set; }

        public OrganisationProgram OrganisationProgram { get; set; }
    }
}
