extends StaticBody2D

var hp = 10

func _ready():
	Input.mouse_mode = Input.MOUSE_MODE_HIDDEN

func _on_area_2d_body_entered(body):
	body.queue_free()
	hp -= 1
	$TextureProgressBar.value = hp * 10
