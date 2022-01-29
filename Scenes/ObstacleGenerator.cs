using Godot;
using System;
using System.Collections.Generic;

public class ObstacleGenerator : Node
{
	[Export] public int ScrollSpeed = 100;
	[Export] public int Frequency = 1000;

	private PackedScene ObstacleScene = ResourceLoader.Load<PackedScene>("res://Scenes/Obstacle.tscn");
	private List<Obstacle> Obstacles = new List<Obstacle>();
	private Random random = new Random();

	public override void _Ready() {
		
	}

	public override void _PhysicsProcess(float delta) {
		if (random.Next(0, Frequency) == 0) {
			createObstacle();
		}
	}

	public void createObstacle() {
		Console.WriteLine("New Obstacle");

		Obstacle newObs = (Obstacle) ObstacleScene.Instance();
		newObs.init(ScrollSpeed);
		newObs.Position = new Vector2(600, 400);

		AddChild(newObs);
		// Obstacles.Add(newObs);
	}
}
