using Godot;
using System;

public partial class Tower : StaticBody2D
{
    private int hp = 10;

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    private void _OnArea2DBodyEntered(Node body)
    {
        body.QueueFree();
        hp -= 1;
        GetNode<TextureProgressBar>("TextureProgressBar").Value = hp * 10;
    }
}