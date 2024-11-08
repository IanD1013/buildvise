namespace _2.State;

public class Character()
{
    private ICharacterState _state = new NormalState();
    public int Health { get; private set; } = 100;
    public bool HasPowerUp { get; private set; } = false;

    public void SetState(ICharacterState state)
    {
        Console.WriteLine($"Switching state to {state.GetType().Name}");
        _state = state;
    }
    
    public void TakeDamage(int amount)
    {
        _state.HandleDamage(this, amount);
    }
    public void CollectPowerUp()
    {
        _state.HandlePowerUpCollected(this);
    }
    
    public void Update()
    {
        _state.HandleUpdate(this);
    }

    public void ModifyHealth(int amount)
    {
        Health = Math.Clamp(Health + amount, 0, 100);   
    }

    public void SetPowerUp(bool hasPowerUp)
    {
        HasPowerUp = hasPowerUp;
    }
}