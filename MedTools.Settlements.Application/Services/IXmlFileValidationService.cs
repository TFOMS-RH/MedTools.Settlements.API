using MedTools.Settlements.Application.Models.Results;

namespace MedTools.Settlements.Application.Services;

public interface IXmlFileValidationService
{
    public XmlFileValidationResult Validate(
        string filename,
        Stream fileStream);

}
