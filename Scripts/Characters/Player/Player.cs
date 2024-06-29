using System;
using Godot;

public partial class Player : CharacterBody3D
{
    private Vector2 direction = new();

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0f, direction.Y);
        Velocity *= 5;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
    }
}
