shader_type canvas_item;
uniform vec4 color = vec4(0,0,0,0); 

void fragment() {
	if(texture(TEXTURE, UV) == vec4(1.0, 1.0, 1.0, 1.0)){
		COLOR = color;
	}
}
