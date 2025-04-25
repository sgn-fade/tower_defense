using Godot;

namespace tower_deff.scripts;

public partial class ManaStone : StaticBody2D
{
    private AnimationPlayer _player;
    private bool _mouseInArea;
    private Ui _ui;
    [Export] private float Radius = 100f;
    private float CurrentRadius = 100f;
    private float TargetRadius = 50f;
    [Export]private float shrinkSpeed = 100f;

    public override void _Ready()
    {
        _player = GetNode<AnimationPlayer>("AnimationPlayer");
        _ui = GetNode<Ui>("/root/game/ui");
        CurrentRadius = 0;
        TargetRadius = 0;
        QueueRedraw();
    }

    public override void _Process(double delta)
    {
        if (CurrentRadius > 0)
        {
            CurrentRadius -= (float)delta * shrinkSpeed;
        }


        QueueRedraw();
    }

    public override void _Input(InputEvent @event)
    {
        if (!Input.IsActionJustPressed("LMB")) return;

        if (CurrentRadius > 0)
        {
            if (CurrentRadius <= TargetRadius + 5 && CurrentRadius >= TargetRadius - 5)
            {
                WorldData.EnemyKilled(1);
            }
            else
            {
                WorldData.EnemyKilled(-1);
            }

            CurrentRadius = 0;
            TargetRadius = 0;
            return;
        }
        TargetRadius = GD.Randi() % 50 + 20;
        CurrentRadius = Radius;
    }

    private void _onArea2dAreaEntered(Node2D area)
    {
        if (area.GetParent() is PlayerMouse)
        {
            _ui.ChangeCursoreTexture("pickaxe");
            _mouseInArea = true;
        }
    }

    private void _OnArea2dAreaExited(Node2D area)
    {
        if (area.GetParent() is PlayerMouse)
        {
            _ui.ChangeCursoreTexture("sword");
            _mouseInArea = false;
        }
    }

    public override void _Draw()
    {
        Vector2 center = new Vector2(0, -20);
        float startAngle = 0f;
        float endAngle = Mathf.Tau;
        int pointCount = 64;
        Color color = Colors.Green;
        float thickness = 8f;

        DrawArc(center, TargetRadius, startAngle, endAngle, pointCount, color, thickness);

        Color color2 = Colors.Black;
        int pointCount2 = 64;
        float thickness2 = 6f;

        if (CurrentRadius > 0)
            DrawArc(center, CurrentRadius, 0, Mathf.Tau, pointCount2, color2, thickness2);
    }
}