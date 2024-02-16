using Godot;
public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    protected Vector3 GetPointGlobalPosition(int pointIndex)
    {
        Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(pointIndex);
        Vector3 globalPos = characterNode.PathNode.GlobalPosition;
        return globalPos + localPos;
    }

    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);

        characterNode.MoveAndSlide();
    }
}
