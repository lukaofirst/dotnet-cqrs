namespace Application.Exceptions;

public class EntityNotFoundException(string message) : ApplicationException(message)
{
}
