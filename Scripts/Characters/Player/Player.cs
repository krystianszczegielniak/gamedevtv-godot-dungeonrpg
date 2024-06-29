using System;
using Godot;

public partial class Player : CharacterBody3D
{
    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Player _PhysicsProcess");
    }

    public override void _Input(InputEvent @event)
    {
        GD.Print("Input" + @event);
    }
}
