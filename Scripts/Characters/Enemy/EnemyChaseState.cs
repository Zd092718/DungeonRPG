using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer timerNode;
    private CharacterBody3D target;
    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        timerNode.Timeout += HandleChaseTimeout;
        characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }

    protected override void ExitState()
    {
        timerNode.Timeout -= HandleChaseTimeout;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
    private void HandleChaseTimeout()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }
    
    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }
    
    private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
