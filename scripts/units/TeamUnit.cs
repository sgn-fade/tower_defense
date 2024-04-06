using Godot;

namespace tower_deff.scripts.units;

public partial class TeamUnit : Unit
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

    
    private void _onDetectAreaBodyEntered(Node2D body)
    {
        if (body is Enemy enemy)
        {
            TargetBody = enemy;
        }
        
    }

}