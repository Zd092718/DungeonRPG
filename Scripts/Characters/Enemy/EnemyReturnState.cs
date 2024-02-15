using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(0);
        Vector3 globalPos = characterNode.PathNode.GlobalPosition;
        destination = globalPos + localPos;
    }

    protected override void EnterState()
    {
        characterNode.AnimSprite.Play(GameConstants.ANIM_MOVE);


        characterNode.GlobalPosition = destination;
    }
}
