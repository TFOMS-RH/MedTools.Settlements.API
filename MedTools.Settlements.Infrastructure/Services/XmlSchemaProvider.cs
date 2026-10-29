using System.Xml.Schema;

using MedTools.Settlements.Domain.Enums;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class XmlSchemaProvider
{
    private readonly Dictionary<XmlFormat, XmlSchemaSet> _schemas;
    public XmlSchemaProvider()
    {
        _schemas = new()
        {
            [XmlFormat.S] = LoadSchema(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "Common",
                    "Schemas",
                    "interterritoirial_format_S")),

            [XmlFormat.Z] = LoadSchema(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "Common",
                    "Schemas",
                    "interterritoirial_format_Z"))
        };
    }

    public XmlSchemaSet GetXmlSchema(XmlFormat format) => _schemas[format];

    private static XmlSchemaSet LoadSchema(string path)
    {
        var xmlSchemaSet = new XmlSchemaSet()
        {
            XmlResolver = null
        };

        xmlSchemaSet.Add(null, path);
        xmlSchemaSet.Compile();

        return xmlSchemaSet;
    }
}
