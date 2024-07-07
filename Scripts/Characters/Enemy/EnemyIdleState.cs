using System;
using Godot;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ANIM_IDLE);
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        characterNode.StateMachine.SwitchState<EnemyReturnState>();
    }
}
