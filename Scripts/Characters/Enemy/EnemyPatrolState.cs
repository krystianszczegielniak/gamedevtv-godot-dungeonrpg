using System;
using Godot;

public partial class EnemyPatrolState : EnemyState
{
    [Export]
    private Timer idleTimerNode;

    [Export(PropertyHint.Range, "0,20,0.1")]
    private float maxIdleTime = 4.0f;
    private int pointIdx = 0;

    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_WALKING);

        pointIdx = 1;

        destination = GetPointGlobalPosition(pointIdx);
        characterNode.AgentNode.TargetPosition = destination;

        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
        idleTimerNode.Timeout += HandleTimeout;
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.AgentNode.NavigationFinished -= HandleNavigationFinished;
        idleTimerNode.Timeout -= HandleTimeout;
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!idleTimerNode.IsStopped())
        {
            return;
        }
        Move();
    }

    private void HandleNavigationFinished()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_IDLE);

        RandomNumberGenerator rng = new();
        idleTimerNode.WaitTime = rng.RandfRange(0, maxIdleTime);
        idleTimerNode.Start();
    }

    private void HandleTimeout()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_WALKING);

        pointIdx = Mathf.Wrap(pointIdx + 1, 0, characterNode.PathNode.Curve.PointCount);

        destination = GetPointGlobalPosition(pointIdx);
        characterNode.AgentNode.TargetPosition = destination;
    }
}
