using Godot;
using Godot.Collections;

namespace tower_deff.scripts;


public partial class Ui : CanvasLayer
{
	private Dictionary<string, Texture2D> _cursorTypes = new Dictionary<string, Texture2D>();

	private Sprite2D _mouse;
	
	public override void _Ready()
	{
		_cursorTypes["pickaxe"] = GD.Load<Texture2D>("res://Sprites/Mouse/mousePickaxe.png");
		_cursorTypes["sword"] = GD.Load<Texture2D>("res://Sprites/Mouse/sword.png");
		_mouse = GetNode<Sprite2D>("mouse");
	}

	public override void _Process(double delta)
	{
		_mouse.GlobalPosition = _mouse.GetGlobalMousePosition();
	}
	public void ChangeCursoreTexture(string value)
	{
		_mouse.Texture = _cursorTypes[value];
	}
}