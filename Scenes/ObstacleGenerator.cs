using Godot;
using System;
using System.Collections.Generic;

public class ObstacleGenerator : Node
{
	[Export] public int ScrollSpeed = 100;
	[Export] public int Frequency = 500;
    [Export] public int Cooldown = 50;
    private int timer = 0;

	private PackedScene ObstacleScene = ResourceLoader.Load<PackedScene>("res://Scenes/Obstacle.tscn");
	private List<Obstacle> Obstacles = new List<Obstacle>();
	private Random random = new Random();

    private bool spawnTop = true;

	public override void _Ready() {
		createObstacle();
	}

	public override void _PhysicsProcess(float delta) {
		if (random.Next(0, Frequency) == 0) {
			createObstacle();
            // lastXPos = Position.x;
		}
	}

	public void createObstacle() {
		Obstacle newObs = (Obstacle) ObstacleScene.Instance();
		newObs.init(ScrollSpeed, spawnTop);

		AddChild(newObs);
		spawnTop = !spawnTop;
	}
}
