using System.Xml;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Domain.Enums;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class XmlValidationService(XmlSchemaProvider xmlSchemasService) : IXmlValidationService
{
    public List<string> Validate(
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
        while (reader.Read()) ;

        return errors;
    }
}
