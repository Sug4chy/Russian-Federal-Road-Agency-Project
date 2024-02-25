namespace RFRAP.Domain.Exceptions.Errors;

public static class ConflictErrors
{
    public static Error ParamIsNotNull(string objName, string paramName)
        => new(nameof(ParamIsNotNull), 
            $"{paramName} parameter of {objName} already exists (not null)");

    public static Error AlreadyExistsWithUniqueValue(string objName, string uniqueFieldName, 
        string uniqueFieldValue)
        => new(nameof(AlreadyExistsWithUniqueValue),
            $"{objName} with {uniqueFieldName} = {uniqueFieldValue} alreadyExists");
}