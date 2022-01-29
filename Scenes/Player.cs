using Godot;
using System;

public class Player : KinematicBody2D {
	[Export] public int speed = 200;

	 public Vector2 velocity = new Vector2();

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
		velocity = MoveAndSlide(velocity);
	}

	public void jump() {

	}

	public void jumpCut() {
		
	}
}
