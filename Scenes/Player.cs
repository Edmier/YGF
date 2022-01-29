using Godot;
using System;

public class Player : KinematicBody2D {
	[Export] public int speed = 200;

	public Vector2 velocity = new Vector2();

	[Export] public int FallMultiplier = 2;
	[Export] public int LowJumpMultiplier = 10;
	[Export] public int JumpVelocity = 400;

	[Export] public int GravityEffect = 2;
	[Export] public float GRAVITY = 9.81f;

	public void GetInput() {
		velocity = new Vector2();

		velocity.y += GravityEffect / 0.5f;

		// 	//#Jump Physics
		if (velocity.y > 0) { //#Player is falling
			velocity += new Vector2(0, -1 * (-GRAVITY) * (FallMultiplier)); //#Falling action is faster than jumping action | Like in mario
		} else if (velocity.y < 0 && Input.IsActionJustReleased("jump")) { //#Player is jumping 
			Console.WriteLine("nice");
			velocity += new Vector2(0, -1 * (GRAVITY) * (LowJumpMultiplier)); //#Jump Height depends on how long you will hold key
		}

		velocity = MoveAndSlide(velocity, new Vector2(0,-1));

		if (IsOnFloor()) {
			// Console.WriteLine("floor");
			if (Input.IsActionJustPressed("jump")) { 
				velocity = new Vector2(0, -1 * JumpVelocity); //#Normal Jump action
			}
		}

		velocity = MoveAndSlide(velocity);
	}
	public override void _PhysicsProcess(float delta) {
		GetInput();
	}

	public void jump() {
		// velocity.y = -JUMP_VELOCITY;s
	}

	public void jumpStop() {

	}
}
