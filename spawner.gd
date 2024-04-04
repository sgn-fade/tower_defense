extends Node2D
var enemy_scene = load("res://enemy.tscn")


func _ready():
	for i in 100:
		await get_tree().create_timer(1).timeout
		var enemy = enemy_scene.instantiate()
		enemy.global_position = get_child(randi() % get_child_count()).position + Vector2(randi() % 20 - 10, randi() % 20 - 10)
		add_child(enemy)


