namespace EventPilot.Domain.Exceptions;

public class InternalServerException(string message): DomainException(message)
{ }