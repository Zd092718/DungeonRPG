using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer comboTimerNode;
    [Export] private PackedScene lightningScene;
    
    private int comboCounter = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();
        comboTimerNode.Timeout += () => comboCounter = 1;
    }
    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_ATTACK + comboCounter, 2f);
        PerformHit();
        characterNode.AnimSprite.AnimationFinished += HandleAnimationFinished;
        characterNode.HitboxAreaNode.BodyEntered += HandleBodyEntered;
    }


    protected override void ExitState()
    {
        characterNode.AnimSprite.AnimationFinished -= HandleAnimationFinished;
        characterNode.HitboxAreaNode.BodyEntered -= HandleBodyEntered;
        comboTimerNode.Start();
    }
    private void HandleAnimationFinished()
    {
        comboCounter++;
        comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCount + 1);
        
        characterNode.ToggleHitbox(true);
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    private void PerformHit()
    {
        Vector3 newPos = characterNode.AnimSprite.FlipH ? Vector3.Left : Vector3.Right;
        float distanceMultiplier = 0.75f;
        newPos *= distanceMultiplier;
        characterNode.HitboxAreaNode.Position = newPos;
        
        characterNode.ToggleHitbox(false);
    }
    
    private void HandleBodyEntered(Node3D body)
    {
        if (comboCounter != maxComboCount) {return;}

        Node3D lightning = lightningScene.Instantiate<Node3D>();
        GetTree().CurrentScene.AddChild(lightning);
        lightning.GlobalPosition = body.GlobalPosition;
    }
    
}
