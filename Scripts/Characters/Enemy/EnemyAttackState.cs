using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private CharacterBody3D target;
    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_ATTACK);
        
    }
}
