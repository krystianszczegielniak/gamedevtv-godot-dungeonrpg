using System;
using Godot;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();

        destination = GetPointGlobalPosition(0);
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_WALKING);

        characterNode.AgentNode.TargetPosition = destination;
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.AgentNode.IsNavigationFinished())
        {
            GD.Print("Reached Destination");
            characterNode.StateMachine.SwitchState<EnemyPatrolState>();
            return;
        }

        Move();
    }
}
