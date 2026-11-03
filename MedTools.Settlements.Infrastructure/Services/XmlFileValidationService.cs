using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Results;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class XmlFileValidationService : IXmlFileValidationService
{
    public XmlFileValidationResult Validate(
        string filename,
        long fileLength)
    {
        var errors = new List<string>();

        if (!filename.EndsWith(".xml")) errors.Add("Переданный файл имеет формат, отличный от .xml");

        if (fileLength > 50 * 1024 * 1024) errors.Add("Файл превышает допустимый размер");

        return new XmlFileValidationResult(
            IsValid: errors.Count == 0,
            Errors: errors);
    }
}
