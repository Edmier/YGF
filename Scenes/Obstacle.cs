using Godot;
using System;

public class Obstacle : RigidBody2D
{

	[Export] public int ScrollSpeed = 0;

	public void init(int ScrollSpeed) {
		this.ScrollSpeed = ScrollSpeed;
	}

	public override void _Ready() {
		//TODO: Randomly pick what image/type this obstacle is
	}

	public override void _PhysicsProcess(float delta) {
		Position -= new Vector2(ScrollSpeed * delta, 0);

		if (Position.x < -100) {
			QueueFree();
		}
	}
}
