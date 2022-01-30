extends Label




# Declare member variables here
signal good_end


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

var x = 0;

func _on_Timer_timeout():
	if (x == 0): 
		set_text("He told me.")
		x = x + 1
	elif (x == 1): 
		set_text("Of life.")
		x = x + 1
	elif (x == 2): 
		set_text("Of fear.")
		x = x + 1
	elif (x == 3): 
		set_text("Of bravery.")
		x = x + 1
	elif (x == 4): 
		set_text("You'll go far.")
		x = x + 1
	elif (x == 5): 
		set_text("Far from insanity.")
		x = x + 1
	elif (x==6):
		emit_signal("good_end")
		get_tree().change_scene("res://scenes/Good_End_scene.tscn");
	
	
	
