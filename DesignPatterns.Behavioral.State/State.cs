namespace DesignPatterns.Behavioral.State;

public interface State
{
    void Handle(Context context);
}