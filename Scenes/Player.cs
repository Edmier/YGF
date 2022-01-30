using Godot;
using System;

public class Player : KinematicBody2D {
	[Export] public int speed = 200;

	public Vector2 velocity = new Vector2();

	//#Jump 
	[Export] public float fall_gravity_scale = 150.0f;
	[Export] public float low_jump_gravity_scale = 100.0f;
	[Export] public float jump_power = 500.0f;
	private bool jump_released = false;

	//#Physics
	public float earth_gravity = 9.807f;
	[Export] public float gravity_scale = 100.0f;
	private bool on_floor = false;
	private int flip = 1;
    [Export] public int StartXPos = 325;

    private AnimatedSprite _sprite;

	public override void _Ready() {
		flip = Transform.Rotation > 0 ? -1 : 1;
        _sprite = GetNode<AnimatedSprite>("AnimatedSprite");

        if (flip == -1) {            
            _sprite.Animation = "flip";
            _sprite.FlipH = true;
        }

	}

	public void GetInput(float delta) {
		if (Input.IsActionJustReleased("jump"))
			jump_released = true;

		// #Applying gravity to player
		velocity += new Vector2(0, 1) * earth_gravity * gravity_scale * delta * flip;

		// #Jump Physics
		if (flip == -1 ? velocity.y < 0 : velocity.y > 0) { // #Player is falling
			// #Falling action is faster than jumping action | Like in mario
			// #On falling we apply a second gravity to the player
			// #We apply ((gravity_scale + fall_gravity_scale) * earth_gravity) gravity on the player
			velocity += new Vector2(0, 1) * earth_gravity * fall_gravity_scale * delta * flip;
		} else if ((flip == -1 ? velocity.y > 0 : velocity.y < 0) && jump_released) {// #Player is jumping 
			// #Jump Height depends on how long you will hold key
			// #If we release the jump before reaching the max height 
			// #We apply ((gravity_scale + low_jump_gravity_scale) * earth_gravity) gravity on the player
			// #It result on a lower jump
			velocity += new Vector2(0, 1) * earth_gravity * low_jump_gravity_scale * delta * flip;
		}

		if (on_floor) {
			if (Input.IsActionJustPressed("jump")) {
				velocity = new Vector2(0, -1) * jump_power * flip; //#Normal Jump action
				jump_released = false;
			}
		}
		velocity = MoveAndSlide(velocity, new Vector2(0, -1));

		if (IsOnFloor() || IsOnCeiling()) on_floor = true;
		else on_floor = false;
	}
	public override void _PhysicsProcess(float delta) {
        if (Position.x < StartXPos) {
            velocity += new Vector2(0.5f, 0);
            float Opacity = (float) Mathf.InverseLerp(0, StartXPos, Position.x);

            Color color = new Color(1, 1, 1, Opacity);
            _sprite.Modulate = color;
        } else {
            velocity = new Vector2(0, velocity.y);
        }

		if (Position.x < 0) {
			GetTree().ChangeScene("res://scenes/End_Scene.tscn");
		}
        GetInput(delta);
	}

	public void jump() {
		// velocity.y = -JUMP_VELOCITY;s
	}

	public void jumpStop() {
		
	}
	
}
