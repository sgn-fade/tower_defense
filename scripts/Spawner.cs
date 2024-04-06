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
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("LMB"))
        {
            Node2D enemy = (Node2D)_enemyScene.Instantiate();
            enemy.GlobalPosition = GetGlobalMousePosition();
            AddChild(enemy);
        }
        if(Input.IsActionJustPressed("RMB"))
        {
            Node2D team = (Node2D)_teamScene.Instantiate();
            team.GlobalPosition = GetGlobalMousePosition();
            AddChild(team);
        }
    }
}