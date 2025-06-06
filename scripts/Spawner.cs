using Godot;

namespace tower_deff.scripts;

public partial class Spawner : Node2D
{
    private PackedScene _enemyScene;
    private PackedScene _teamScene;

    public override void _Ready()
    {
        _enemyScene = (PackedScene)ResourceLoader.Load("res://enemy.tscn");
        _teamScene = (PackedScene)ResourceLoader.Load("res://team_unit.tscn");
        SpawnEnemies();
    }

    private async void SpawnEnemies()
    {
        for (int i = 0; i < 100; i++)
        {
            await ToSignal(GetTree().CreateTimer(1f), "timeout");
            Node2D enemy = (Node2D)_enemyScene.Instantiate();
            enemy.GlobalPosition = ((Node2D)GetChild((int)(GD.Randi() % GetChildCount()))).Position +
                                   new Vector2(GD.Randi() % 20, GD.Randi() % 20);
            AddChild(enemy);
        }
    }

    // public override void _Process(double delta)
    // {
    //     if (Input.IsActionJustPressed("LMB"))
    //     {
    //         Node2D team = (Node2D)_teamScene.Instantiate();
    //         team.GlobalPosition = GetGlobalMousePosition();
    //         AddChild(team);
    //     }
    // }
}