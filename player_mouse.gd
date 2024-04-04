extends Node2D

var body_enemy = null

func _process(delta):
	global_position = get_global_mouse_position()
	
	if Input.is_action_just_released("LMB") and body_enemy != null:
		WorldData.enemy_killed(1)
		print(WorldData.mana)
		body_enemy.queue_free()




func _on_mouse_body_entered(body):
	body_enemy = body


func _on_mouse_body_exited(body):
	body_enemy = null
