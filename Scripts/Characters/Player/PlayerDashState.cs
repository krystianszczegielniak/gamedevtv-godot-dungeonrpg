using Godot;

public partial class PlayerDashState : PlayerState
{
    [Export]
    private Timer dashTimer;

    [Export(PropertyHint.Range, "0,20,0.1")]
    private float speed = 10f;

    public override void _Ready()
    {
        base._Ready();
        dashTimer.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayer.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(characterNode.direction.X, 0f, characterNode.direction.Y);

        if (characterNode.Velocity == Vector3.Zero)
        {
            characterNode.Velocity = characterNode.CharacterSprite3D.FlipH
                ? Vector3.Left
                : Vector3.Right;
        }

        characterNode.Velocity *= speed;
        dashTimer.Start();
    }

    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.StateMachine.SwitchState<PlayerIdleState>();
    }
}
