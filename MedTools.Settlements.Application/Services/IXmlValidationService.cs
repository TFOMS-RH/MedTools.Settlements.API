using MedTools.Settlements.Domain.Enums;

namespace MedTools.Settlements.Application.Services;

public interface IXmlValidationService
{
    public List<string> Validate(
        Stream fileStream, 
        XmlFormat format);
}
