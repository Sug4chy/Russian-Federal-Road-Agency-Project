namespace RFRAP.Domain.Exceptions;

public class RoadNotFoundException : CustomExceptionBase
{
    /*
     * У тебя в домейне есть using Microsoft.AspNetCore.Http;
     * Но откуда это доступно я чет не понимаю
     * Как лучше в общем?
     */
    public override int StatusCode => 404;

    public RoadNotFoundException()
    {
    }

    public RoadNotFoundException(string message) : base(message)
    {
        
    }

    public RoadNotFoundException(string message, Exception ex)
        : base(message, ex)
    {
        
    }
}