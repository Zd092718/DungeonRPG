using Godot;
using System;

public partial class Bomb : Node3D
{
    [Export] private AnimationPlayer playerNode;
    [Export] public float Damage { get; private set; } = 10;

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
