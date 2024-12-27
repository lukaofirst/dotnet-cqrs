namespace Application.Exceptions;

public class EntityAlreadyExistException(string message) : ApplicationException(message)
{
}
