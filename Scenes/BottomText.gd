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

var x = 0

func _on_Timer_timeout():
	if (x == 0): 
		set_text("He warned me.")
		x = x + 1
	elif (x == 1): 
		set_text("Of death.")
		x = x + 1
	elif (x == 2): 
		set_text("Of desire.")
		x = x + 1
	elif (x == 3): 
		set_text("Of foolishness.")
		x = x + 1
	elif (x == 4): 
		set_text("You'll go far.")
		x = x + 1
