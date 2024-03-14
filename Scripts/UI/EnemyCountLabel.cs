using Godot;
using System;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.OnNewEnemyCount += HandleNewEnemyCount;
    }
    private void HandleNewEnemyCount(int count)
    {
        GD.Print(count);
        Text = count.ToString();
    }
}
