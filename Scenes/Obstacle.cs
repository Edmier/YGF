using Godot;
using System;

public class Obstacle : StaticBody2D
{

	[Export] public int ScrollSpeed = 0;

	public void init(int ScrollSpeed, bool onTop) {
		this.ScrollSpeed = ScrollSpeed;
        Position = new Vector2(1350, onTop ? 310 : 380);

        if (onTop) {
            AnimatedSprite _sprite = GetNode<AnimatedSprite>("Sprite");
            _sprite.FlipV = true;
            _sprite.Modulate = new Color(0, 0, 0, 255);
            _sprite.Frame = new Random().Next(0, 4);
        }
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
