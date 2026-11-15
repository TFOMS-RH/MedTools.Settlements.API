namespace MedTools.Settlements.Web.Common.Extensions;

public static class ValidationProblemExtensions
{
    public static Dictionary<string, string[]> AddError(
        this Dictionary<string, string[]> validationProblems,
        string field,
        string error)
    {
        if (validationProblems.TryGetValue(
            field,
            out var errors))
        {
            validationProblems[field] = [.. errors, error];
        }
        else
        {
            validationProblems[field] = [error];
        }


        return validationProblems;
    }
}
