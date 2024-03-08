using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPosition;
    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_ATTACK);
        
        Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().First();
        targetPosition = target.GlobalPosition;

        CallDeferred("PerformHit");
        
        characterNode.AnimSprite.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        characterNode.AnimSprite.AnimationFinished -= HandleAnimationFinished;
    }
    private void HandleAnimationFinished()
    {
        characterNode.ToggleHitbox(true);

        Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().FirstOrDefault();
        if (target == null)
        {
            Node3D chaseTarget = characterNode.ChaseAreaNode.GetOverlappingBodies().FirstOrDefault();

            if (chaseTarget == null)
            {
                characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
                return;
            }
            
            characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
            return;
        }
        characterNode.AnimSprite.Play(GameConstants.ANIM_ATTACK);
        CallDeferred("PerformHit");
        targetPosition = target.GlobalPosition;
        
        Vector3 direction = characterNode.GlobalPosition.DirectionTo(targetPosition);
        characterNode.AnimSprite.FlipH = direction.X < 0;
    }

    private void PerformHit()
    {
        characterNode.ToggleHitbox(false);
        characterNode.HitboxAreaNode.GlobalPosition = targetPosition;
    }
}
