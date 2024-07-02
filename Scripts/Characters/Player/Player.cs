using System;
using Godot;

public partial class Player : CharacterBody3D
{
    [ExportGroup("RequiredNodes")]
    [Export]
    public AnimationPlayer AnimationPlayer { get; private set; }

    [Export]
    public Sprite3D CharacterSprite3D { get; private set; }

    [Export]
    public StateMachine StateMachine { get; private set; }

    public Vector2 direction = new();

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.INPUT_MOVE_LEFT,
            GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_FORWARD,
            GameConstants.INPUT_MOVE_BACKWARD
        );
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
            return;

        bool isMovingLeft = Velocity.X < 0;
        CharacterSprite3D.FlipH = isMovingLeft;
    }
}
