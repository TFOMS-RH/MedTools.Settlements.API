using System.Xml;
using System.Xml.Serialization;

using MedTools.Settlements.Domain.Enums;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class ReconciliationActXmlValidationService(
    XmlSchemaProvider xmlSchemasService) : IXmlValidationService<ReconciliationActFileRoot>
{
    public XmlValidationResult<ReconciliationActFileRoot> Validate(
        Stream fileStream,
        XmlFormat format)
    {
        var errors = new List<string>();

        var readerSettings = new XmlReaderSettings()
        {
            Schemas = xmlSchemasService.GetXmlSchema(format),
            MaxCharactersInDocument = 1_000_000,
            ValidationType = ValidationType.Schema,
        };

        readerSettings.ValidationEventHandler += (_, eventArgs) => errors.Add(eventArgs.Message);

        var reader = XmlReader.Create(fileStream, readerSettings);
        var serializer = new XmlSerializer(typeof(ReconciliationActFileRoot));

        var value = serializer.Deserialize(reader);

        if (value is not ReconciliationActFileRoot deserializeValue)
        {
            return new XmlValidationResult<ReconciliationActFileRoot>(
                null,
                errors);
        }

        return new XmlValidationResult<ReconciliationActFileRoot>(
            Value: deserializeValue,
            Errors: errors);
    }

}
