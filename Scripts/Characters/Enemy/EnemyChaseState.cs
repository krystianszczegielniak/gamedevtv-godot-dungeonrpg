using System;
using Godot;

public partial class EnemyChaseState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_WALKING);
    }
}
