using Godot;

namespace tower_deff.scripts;

public partial class WorldData : Node
{
	private static manaUi _manaUi;
	private static int _mana = 0;

	public override void _Ready()
	{
		_manaUi = GetNode("/root/game/ui/mana_ui") as manaUi;

	}
	public static void EnemyKilled(int value)
	{
		_mana += value;
		_manaUi.Update(_mana);
	}

	public int Mana
	{
		get => _mana;
		set => _mana = value;
	}
}