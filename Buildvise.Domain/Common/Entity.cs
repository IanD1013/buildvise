namespace Buildvise.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; init; }
    
    protected Entity(Guid id) => Id = id;
    
    protected Entity()
    {
    }
}