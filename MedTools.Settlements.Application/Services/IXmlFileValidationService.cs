using MedTools.Settlements.Application.Models.Results;
using System.Net.Sockets;

namespace MedTools.Settlements.Application.Services;

public interface IXmlFileValidationService
{
    public XmlFileValidationResult Validate(
        string filename,
        long fileLength);

}
