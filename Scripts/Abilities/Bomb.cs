using Godot;
using System;

public partial class Bomb : Ability
{
    public override void _Ready()
    {
        playerNode.AnimationFinished += HandleExpandAnimationFinished;
    }
    private void HandleExpandAnimationFinished(StringName animname)
    {
        if (animname == GameConstants.ANIM_EXPAND)
        {
            playerNode.Play(GameConstants.ANIM_EXPLOSION);
        }
        else
        {
            QueueFree();    
        }
    }
}
