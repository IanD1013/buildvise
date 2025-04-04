namespace DesignPatterns.Behavioral.State;

public class NormalState : ICharacterState
{
    public void HandleDamage(Character character, int amount)
    {
        character.ModifyHealth(-amount);

        if (character.Health < 30)
        {
            character.SetState(new InjuredState());
        }
    }
    
    public void HandlePowerUpCollected(Character character)
    {
        character.SetPowerUp(true);
        character.SetState(new PowerUpState());
    }
    
    public void HandleUpdate(Character character)
    {
    }
}