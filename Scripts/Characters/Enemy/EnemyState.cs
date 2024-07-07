using Godot;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    protected Vector3 GetPointGlobalPosition(int pointIdx)
    {
        Vector3 localPosition = characterNode.PathNode.Curve.GetPointPosition(pointIdx);
        Vector3 globalPosition = characterNode.PathNode.GlobalPosition;
        return globalPosition + localPosition;
    }

    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
        characterNode.MoveAndSlide();
    }

    protected void HandleChaseAreaBodyEntered(Node3D _)
    {
        characterNode.StateMachine.SwitchState<EnemyChaseState>();
    }
}
