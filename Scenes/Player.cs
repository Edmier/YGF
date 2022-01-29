using Godot;
using System;

public class Player : KinematicBody2D {
	[Export] public int speed = 200;

	public Vector2 velocity = new Vector2();

	[Export] public int fallMultiplier = 2;
	[Export] public int lowJumpMultiplier = 10;
	[Export] public int jumpVelocity = 400;

	public void GetInput() {
		velocity = new Vector2();

		if (Input.IsActionJustPressed("jump"))
			jump();

		if (Input.IsActionJustReleased("jump"))
			jumpStop();

		velocity = velocity.Normalized() * speed;
	}
	public override void _PhysicsProcess(float delta) {
		GetInput();

		velocity.y += Gravity;

			//#Jump Physics
		if (velocity.y > 0) { //#Player is falling
			velocity += Vector2.UP * (-9.81) * (FallMultiplier); //#Falling action is faster than jumping action | Like in mario
		}
		else if (velocity.y < 0 && Input.IsActionJustReleased("jump")) { //#Player is jumping 
			velocity += Vector2.UP * (-9.81) * (LowJumpMultiplier); //#Jump Height depends on how long you will hold key
		}
		if (IsOnFloor()) {
			if (Input.IsActionJustPressed("jump")) { 
				velocity = Vector2.UP * JumpVelocity; //#Normal Jump action
			}
		}

		velocity = MoveAndSlide(velocity, Vector2(0,-1));

		velocity = MoveAndSlide(velocity);
	}

	public override void _PhysicsProcess(float delta) {
		GetInput();
		velocity = MoveAndSlide(velocity);
	}

	public void jump() {

	}

	public void jumpCut() {
		
	}
	public void jump() {
		// velocity.y = -JUMP_VELOCITY;s
	}

	public void jump() {
		// velocity.y = -JUMP_VELOCITY;s
	}

	public void jumpStop() {

	}
}
