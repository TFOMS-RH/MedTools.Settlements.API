using MedTools.Settlements.Domain.Enums;
using MedTools.Settlements.Application.Models.Results;

namespace MedTools.Settlements.Application.Services;

public interface IXmlValidationService<T> where T : class
{
    public XmlValidationResult<T> Validate(
        Stream fileStream,
        XmlFormat format);
}
