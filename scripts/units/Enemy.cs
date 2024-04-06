using Godot;

namespace tower_deff.scripts.units;

public partial class Enemy : Unit
{
    public override void _Ready()
    {
        MoveTarget = Vector2.Zero;
        HpBar = GetNode<TextureProgressBar>("hpBar");
        DamageParticles = GetNode<CpuParticles2D>("damageParticles");
        Core = GetNode<Node2D>("core");
        AttackArea = GetNode<Area2D>("core/attackArea");
        AttackArea.SetDeferred("monitoring", true);

    }

    public override void _Process(double delta)
    {
        if (!IsInstanceValid(TargetBody) || TargetBody == null)
        {
            MoveTarget = Vector2.Zero;
            Move();
            return;
        }
        MoveTarget = TargetBody.GlobalPosition;
        Move();
    }

    private void _onDetectAreaBodyEntered(Node2D body)
    {
        if (body is TeamUnit unit)
        {
            TargetBody = unit;
        }
    }
}