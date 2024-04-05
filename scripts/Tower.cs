using Godot;

namespace tower_deff.scripts;

public partial class Tower : StaticBody2D
{
    private int _hp = 10;

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    private void _OnArea2DBodyEntered(Node body)
    {
        body.QueueFree();
        _hp -= 1;
        GetNode<TextureProgressBar>("TextureProgressBar").Value = _hp * 10;
    }
}