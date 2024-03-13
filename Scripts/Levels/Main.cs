using Godot;
using System;

public partial class Main : Node3D
{
    public override void _Ready()
    {
        GetTree().Paused = true;
    }
    public override void _Process(double delta)
    {
        // For testing only
        if (Input.IsKeyPressed(Key.Escape))
        {
            GetTree().Quit();
        }
    }
}
