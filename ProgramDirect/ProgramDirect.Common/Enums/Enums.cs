namespace ProgramDirect.Common.Enums
{
    public enum ApiResponseCode
    {
        Ok,
        ProcessingError,
        BadRequest,
        Forbidden
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum ApplicationQuestionType
    {
        Paragraph, 
        YesNo, 
        Dropdown, 
        MultipleChoice,
        Date, 
        Number
    }
}
