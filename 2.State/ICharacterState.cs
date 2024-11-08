namespace _2.State;

public interface ICharacterState
{
    void HandleDamage(Character character, int amount);
    void HandlePowerUpCollected(Character character);
    void HandleUpdate(Character character);
}