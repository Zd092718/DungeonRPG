using Godot;
using System;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_DEATH);
        characterNode.AnimSprite.AnimationFinished += HandleAnimationFinished;
    }
    private void HandleAnimationFinished()
    {
        characterNode.QueueFree();
    }
}
