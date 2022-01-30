extends Label


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
var x = 4
func _on_Timer_timeout():
	if (x == 4): 
		set_text("You'll go far.")
		x = x + 1
	elif (x == 5): 
		set_text("Far from being free.")
