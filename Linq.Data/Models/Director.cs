namespace Linq.Data.Models;

public record Director(string FirstName, string LastName, string FullName)
{
    public override string ToString()
    {
        return FullName;
    }
}