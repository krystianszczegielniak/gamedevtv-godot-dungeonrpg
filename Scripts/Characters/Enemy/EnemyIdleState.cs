using System;
using Godot;

public abstract partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ANIM_IDLE);
    }
}
