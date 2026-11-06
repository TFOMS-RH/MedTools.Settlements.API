using System.Xml;
using System.Xml.Serialization;

using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class ReconciliationActXmlDeserializationService(
    XmlSchemaProvider xmlSchemasService) : IXmlDeserializationService<ReconciliationActFileRoot>
{
    public XmlDeserializationResult<ReconciliationActFileRoot> Deserialize(
        Stream source,
        XmlFormat format)
    {
        try
        {
            var schemaValidationErrors = new List<string>();

            var readerSettings = new XmlReaderSettings()
            {
                Schemas = xmlSchemasService.GetXmlSchema(format),
                MaxCharactersInDocument = 1_000_000,
                ValidationType = ValidationType.Schema,
            };

            readerSettings.ValidationEventHandler += (_, eventArgs) => schemaValidationErrors.Add(eventArgs.Message);

            using var reader = XmlReader.Create(source, readerSettings);
            var serializer = new XmlSerializer(typeof(ReconciliationActFileRoot));

            var value = serializer.Deserialize(reader);

            if (value is not ReconciliationActFileRoot deserializeValue)
            {
                return new XmlDeserializationResult<ReconciliationActFileRoot>(
                    null,
                    schemaValidationErrors);
            }

            return new XmlDeserializationResult<ReconciliationActFileRoot>(
                Value: deserializeValue,
                SchemaValidationErrors: schemaValidationErrors);

        }
        catch (InvalidOperationException ex)
        {
            return new XmlDeserializationResult<ReconciliationActFileRoot>(
                Value: null,
                SchemaValidationErrors: [$"Критическая ошибка проверки XML-файла: {ex.Message}"]);
        }

    }

}
