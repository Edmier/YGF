using Godot;
using System;
using System.Collections.Generic;

public class ObstacleGenerator : Node
{
	[Export] public int ScrollSpeed = 50;
	[Export] public int Frequency = 10;
    [Export] public int Cooldown = 10;
    private double Timer = 0;

	private PackedScene ObstacleScene = ResourceLoader.Load<PackedScene>("res://Scenes/Obstacle.tscn");
	private List<Obstacle> Obstacles = new List<Obstacle>();
	private Random random = new Random();

    private bool spawnTop = true;

	public override void _Ready() {
		createObstacle();
	}

	public override void _PhysicsProcess(float delta) {
		if (random.Next(0, Frequency) == 0 && Timer <= 0) {
			createObstacle();
            Timer = Cooldown;
		}
        if (Timer > 0) {
            Timer -= 0.8 + (0.8 * delta);
        }
	}

	public void createObstacle() {
		Obstacle newObs = (Obstacle) ObstacleScene.Instance();
		newObs.init(ScrollSpeed, spawnTop);

		AddChild(newObs);
		spawnTop = !spawnTop;
	}

    public void CrossedThreshold() {
        Console.WriteLine("Wild");
    }
}
