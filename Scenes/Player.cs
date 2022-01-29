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
        velocity = MoveAndSlide(velocity);
    }

    public void jump() {
        // velocity.y = -JUMP_VELOCITY;s
    }

    public void jumpStop() {

    }
}
