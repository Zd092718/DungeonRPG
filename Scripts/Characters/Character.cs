﻿using Godot;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;
    
    [ExportGroup("Required Nodes")]
    [Export] public AnimatedSprite3D AnimSprite { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    [Export] public Area3D HurtboxAreaNode { get; private set; }

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode { get; private set; }
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    [Export] public Area3D ChaseAreaNode { get; private set; }
    [Export] public Area3D AttackAreaNode { get; private set; }
    

    public Vector2 direction = new();

    public override void _Ready()
    {
        HurtboxAreaNode.AreaEntered += HandleHurtboxAreaEntered;
    }
    private void HandleHurtboxAreaEntered(Area3D area)
    {
        GD.Print($"{area.Name} hit");
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }

        bool isMovingLeft = Velocity.X < 0;
        AnimSprite.FlipH = isMovingLeft;
    }
}
