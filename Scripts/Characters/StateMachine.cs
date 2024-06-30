using System.Linq;
using Godot;

public partial class StateMachine : Node
{
    [Export]
    private Node currentState;

    [Export]
    private Node[] states;

    public override void _Ready()
    {
        currentState.Notification(5001);
    }

    public void SwitchState<T>()
        where T : Node
    {
        var newState = states.FirstOrDefault(s => s is T);

        if (newState == null)
            return;

        currentState.Notification(5002);
        currentState = newState;
        currentState.Notification(5001);
    }
}
