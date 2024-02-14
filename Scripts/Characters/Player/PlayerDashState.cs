using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export(PropertyHint.Range, "0, 30,0.1")] private float dashSpeed = 10;

    public override void _Ready()
    {
        base._Ready();

        dashTimerNode.Timeout += HandleDashTimeout;
    }


    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        if (characterNode.Velocity == Vector3.Zero)
        {
            characterNode.Velocity = characterNode.AnimSprite.FlipH ? Vector3.Left : Vector3.Right;
        }
        characterNode.Velocity *= dashSpeed;
        dashTimerNode.Start();
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}
