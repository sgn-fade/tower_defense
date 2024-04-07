using Godot;

namespace tower_deff.scripts;

public partial class ManaStone : StaticBody2D
{
    private AnimationPlayer _player;
    private Sprite2D _circle;
    private bool _mouseInArea;
    
    public override void _Ready()
    {
        _player = GetNode<AnimationPlayer>("AnimationPlayer");
        _circle = GetNode<Sprite2D>("Circle");

    }

    public override void _Process(double delta)
    {
        if (_mouseInArea && Input.IsActionJustPressed("LMB"))
        {
            if (_player.IsPlaying())
            {
                if (_circle.Scale.X < 0.307 && _circle.Scale.X > 0.179)
                {
                    WorldData.EnemyKilled(1);
                }
            }
            else
            {
                _player.Play("start");
            }
        }
    }

    private void _onArea2dAreaEntered(Node2D area)
    {
        
        if (area.GetParent() is PlayerMouse)
        {
            GD.Print(true);
            _mouseInArea = true;
        }
    }
}