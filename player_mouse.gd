extends Node2D

func _process(delta):
	global_position = get_global_mouse_position()

func _input(event):
	if Input.is_action_just_pressed("LMB"):
		for body in $mouse.get_overlapping_areas():
			if body.name == "enemy":
				WorldData.enemy_killed(1)
				body.get_parent().queue_free()
				return
