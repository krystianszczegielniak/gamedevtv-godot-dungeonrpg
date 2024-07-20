using System;
using System.Linq;
using Godot;

public partial class EnemyChaseState : EnemyState
{
    [Export]
    private Timer timer;

    private CharacterBody3D target;

    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_WALKING);
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        timer.Timeout += HandleDestinationChangeTimeout;

        characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }

    protected override void ExitState()
    {
        timer.Timeout -= HandleDestinationChangeTimeout;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }

    private void HandleDestinationChangeTimeout()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandleAttackAreaBodyEntered(Node3D _)
    {
        characterNode.StateMachine.SwitchState<EnemyAttackState>();
    }

    private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachine.SwitchState<EnemyReturnState>();
    }
}
