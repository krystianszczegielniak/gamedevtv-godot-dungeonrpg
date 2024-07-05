using Godot;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("RequiredNodes")]
    [Export]
    public AnimationPlayer AnimationPlayer { get; private set; }

    [Export]
    public Sprite3D CharacterSprite3D { get; private set; }

    [Export]
    public StateMachine StateMachine { get; private set; }

    public Vector2 direction = new();

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
            return;

        bool isMovingLeft = Velocity.X < 0;
        CharacterSprite3D.FlipH = isMovingLeft;
    }
}
