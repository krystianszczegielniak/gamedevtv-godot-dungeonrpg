using System.IO;
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

    [ExportGroup("AI Nodes")]
    [Export]
    public Path3D PathNode { get; private set; }

    [Export]
    public NavigationAgent3D AgentNode { get; private set; }

    [Export]
    public Area3D ChaseAreaNode { get; private set; }

    [Export]
    public Area3D AttackAreaNode { get; private set; }

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
