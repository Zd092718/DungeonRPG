using Godot;
using System;

public partial class StatLabel : Label
{
    [Export] public StatResource statResource;

    public override void _Ready()
    {
        statResource.OnUpdate += HandleStatUpdate;
        
        Text = statResource.StatValue.ToString();
    }
    private void HandleStatUpdate()
    {
        Text = statResource.StatValue.ToString();
    }
}
