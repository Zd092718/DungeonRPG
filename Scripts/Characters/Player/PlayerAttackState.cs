using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer comboTimerNode;
    
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
        characterNode.AnimSprite.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        characterNode.AnimSprite.AnimationFinished -= HandleAnimationFinished;
        comboTimerNode.Start();
    }
    private void HandleAnimationFinished()
    {
        comboCounter++;
        comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCount + 1);
        
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
    
}
