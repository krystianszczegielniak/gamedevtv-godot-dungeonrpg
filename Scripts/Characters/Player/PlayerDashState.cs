using Godot;

public partial class PlayerDashState : Node
{
    [Export]
    private Timer dashTimer;

    [Export]
    private float speed = 30f;

    private Player characterNode;

    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        dashTimer.Timeout += HandleDashTimeout;
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            SetPhysicsProcess(true);
            characterNode.animationPlayer.Play(GameConstants.ANIM_DASH);
            characterNode.Velocity = new(characterNode.direction.X, 0f, characterNode.direction.Y);
            if (characterNode.Velocity == Vector3.Zero)
            {
                characterNode.Velocity = characterNode.characterSprite3D.FlipH
                    ? Vector3.Left
                    : Vector3.Right;
            }
            characterNode.Velocity *= speed;

            dashTimer.Start();
        }
        if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }

    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.stateMachine.SwitchState<PlayerIdleState>();
    }
}
