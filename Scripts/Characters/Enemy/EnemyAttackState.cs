using System;
using Godot;

public partial class EnemyAttackState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ENEMY_ANIM_SLASHING);
    }
}
