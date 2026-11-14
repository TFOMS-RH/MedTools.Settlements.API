using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Models.Results;

namespace MedTools.Settlements.Application.Services;

public interface IXmlDeserializationService<TEntity> where TEntity : class
{
    public XmlDeserializationResult<TEntity> Deserialize(
        Stream source,
        XmlFormat format);
}
