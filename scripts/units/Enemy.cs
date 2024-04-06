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
    }

    private void _onDetectAreaBodyEntered(Node2D body)
    {
        if (body.Name == "teamUnit")
        {
            TargetBody = (Unit)body;
        }
    }
}