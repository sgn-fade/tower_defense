extends CharacterBody2D

func _process(delta):
	set_velocity((Vector2.ZERO - global_position).normalized() * 100)
	move_and_slide()

