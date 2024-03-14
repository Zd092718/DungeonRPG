using Godot;
using System;

public partial class EnemiesContainer : Node3D
{
    public override void _Ready()
    {
        int totalEnemies = GetChildCount();
        
        GameEvents.RaiseOnNewEnemyCount(totalEnemies);

        ChildExitingTree += HandleChildExitingTree;
    }
    private void HandleChildExitingTree(Node node)
    {
        int totalEnemies = GetChildCount() - 1;
        
        GameEvents.RaiseOnNewEnemyCount(totalEnemies);

        if (totalEnemies == 0)
        {
            GameEvents.RaiseOnVictory();
        }
    }
}
