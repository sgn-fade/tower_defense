using Godot;
using System;
using tower_deff.scripts;

public partial class PlayerMouse : Node2D
{
    private tower_deff.scripts.Enemy _bodyEnemy;

    public override void _Process(double delta)
    {
        GlobalPosition = GetGlobalMousePosition();

        if (!Input.IsActionJustPressed("LMB") || _bodyEnemy == null) return;
        _bodyEnemy.Damage(1);

    }

    private void OnMouseBodyEntered(Node body)
    {
        _bodyEnemy = (tower_deff.scripts.Enemy)body;
    }

    private void OnMouseBodyExited(Node body)
    {
        _bodyEnemy = null;
    }
}