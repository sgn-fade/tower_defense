extends Node2D
var enemy_scene = load("res://enemy.tscn")


func _ready():
	for i in 10:
		await get_tree().create_timer(0.5).timeout
		var enemy = enemy_scene.instantiate()
		enemy.global_position = get_child(randi() % get_child_count()).position
		add_child(enemy)
