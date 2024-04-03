extends Node
@onready var mana_ui = get_node("/root/game/ui/mana_ui")
var mana = 0

func enemy_killed(mana_value):
	mana += mana_value
	mana_ui.update(mana)
