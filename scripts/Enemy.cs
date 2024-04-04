using System;
using Godot;

namespace tower_deff.scripts;

public partial class Enemy : CharacterBody2D
{
    private int _hp = 5;
    private TextureProgressBar _hpBar;
    private CpuParticles2D _damageParticles;
    private Sprite2D _sprite2D;

    
    public override void _Ready()
    {
        _hpBar = GetNode<TextureProgressBar>("hpBar");
        _damageParticles = GetNode<CpuParticles2D>("damageParticles");
        _sprite2D = GetNode<Sprite2D>("Sprite2D");
    }

    public override void _Process(double delta)
    {
        Velocity = (Vector2.Zero - GlobalPosition).Normalized() * 100;
        _sprite2D.FlipH = Math.Sign(Velocity.X) > 0;
        MoveAndSlide();
    }

    public void Damage(int value)
    {
        _hp -= value;
        _hpBar.Value = _hp;
        _damageParticles.Emitting = true;
        if (_hp != 0) return;
        WorldData.EnemyKilled(1);
        QueueFree();
    }

    private int Hp
    {
        get => _hp;
        set => _hp = value;
    }
}