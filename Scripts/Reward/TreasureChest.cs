using Godot;
using System;
using System.Linq;

public partial class TreasureChest : StaticBody3D
{
    [Export] private Area3D areaNode;
    [Export] private Sprite3D interactIcon;
    [Export] private RewardResource reward;

    public override void _Ready()
    {
        areaNode.BodyEntered += (body) => interactIcon.Visible = true;
        areaNode.BodyExited += (body) => interactIcon.Visible = false;
    }

    public override void _Input(InputEvent @event)
    {
        if (
            !areaNode.Monitoring || 
            !areaNode.HasOverlappingBodies() || 
            !Input.IsActionJustPressed(GameConstants.INPUT_INTERACT)
            )
        {
            return;
        }
        
        areaNode.Monitoring = false;
        
        GameEvents.RaiseOnReward(reward);
    }
}
