using Godot;

namespace tower_deff.scripts;

public partial class ManaIncreaseValue : Node2D
{
    private AnimationPlayer _player;


    public override async void _Ready()
    {
        _player = GetNode<AnimationPlayer>("player");
        _player.Play("main");
        await ToSignal(_player, "animation_finished");
        QueueFree();
    }

}