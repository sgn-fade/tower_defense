using System.Collections.Generic;
using Godot;

namespace tower_deff.scripts;

public partial class PlayerMouse : Node2D
{
    private units.Enemy _bodyEnemy;
    
    
    public override void _Process(double delta)
    {
        GlobalPosition = GetGlobalMousePosition();

        if (!Input.IsActionJustPressed("LMB") || _bodyEnemy == null) return;
        _bodyEnemy.Damage(1);

    }

    private void OnMouseBodyEntered(Node body)
    {
        if (body is units.Enemy enemy)
        {
            _bodyEnemy = enemy;
        }
    }

    private void OnMouseBodyExited(Node body)
    {
        _bodyEnemy = null;
    }
    
}