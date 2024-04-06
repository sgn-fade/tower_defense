using System;
using Godot;

namespace tower_deff.scripts;

public partial class Unit : CharacterBody2D
{
    private int _hp = 5;
    protected TextureProgressBar HpBar;
    protected CpuParticles2D DamageParticles;
    protected Node2D Core;    
    protected Unit TargetBody;
    protected Area2D AttackArea;

    protected Vector2 MoveTarget;
    
    
    public override void _Process(double delta)
    {
        if (!IsInstanceValid(TargetBody) || TargetBody == null)
        {
            return;
        }
        MoveTarget = TargetBody.GlobalPosition;
        Move();
    }

    protected void Move()
    {
        Velocity = (MoveTarget - GlobalPosition).Normalized() * 100;
        var direction = Math.Sign(Velocity.X) == 0 ? new Vector2(1, 1) : new Vector2(-Math.Sign(Velocity.X), 1);
        Core.Scale = direction;
        MoveAndSlide();
    }
    public void Damage(int value)
    {
        _hp -= value;
        HpBar.Value = _hp;
        DamageParticles.Emitting = true;
        if (_hp != 0) return;
        QueueFree();
    }

    private int Hp
    {
        get => _hp;
        set => _hp = value;
    }

    private async void _onAttackAreaBodyEntered(Node2D body)
    {
        if (body == TargetBody)
        {
            TargetBody.Damage(1);
            AttackArea.SetDeferred("monitoring", false);
            await ToSignal(GetTree().CreateTimer(0.4f), "timeout");
            AttackArea.SetDeferred("monitoring", true);
        }
    }
}