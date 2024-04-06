shader_type canvas_item;

void fragment() {
	if(texture(TEXTURE, UV) == vec4(1.0, 1.0, 1.0, 1.0)){
		COLOR = vec4(0, 0.2, 0.8, 1);
	}
}
