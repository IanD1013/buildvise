namespace DesignPatterns.Behavioral.State;

public class PowerUpState : ICharacterState
{
    private int _powerUpDuration = 10;
    public void HandleDamage(Character character, int amount)
    {
        character.ModifyHealth(-amount / 2);
    }
    
    public void HandlePowerUpCollected(Character character)
    {
        _powerUpDuration = 10;
    }
    
    public void HandleUpdate(Character character)
    {
        _powerUpDuration--;

        if (_powerUpDuration <= 1)
        {
            character.SetPowerUp(false);
            character.SetState(new NormalState());
        }
    }
}