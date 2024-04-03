extends CharacterBody2D

func _ready():
	set_velocity((Vector2.ZERO - global_position).normalized() * 100)
	
func _process(delta):
	move_and_slide()

