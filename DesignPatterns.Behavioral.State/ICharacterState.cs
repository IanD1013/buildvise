namespace DesignPatterns.Behavioral.State;

public interface ICharacterState
{
    void HandleDamage(Character character, int amount);
    void HandleUpdate(Character character);
    void HandlePowerUpCollected(Character character);
}