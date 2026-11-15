namespace MedTools.Settlements.Application.Common.Exceptions;

public sealed class EntityNotFoundException(string message) : Exception(message);
