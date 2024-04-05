using Godot;
	
namespace tower_deff.scripts;

public partial class Ui : CanvasLayer
{
	private Sprite2D _mouse;
	
	public override void _Ready()
	{
		_mouse = GetNode<Sprite2D>("mouse");
	}

	public override void _Process(double delta)
	{
		_mouse.GlobalPosition = _mouse.GetGlobalMousePosition();
	}
}