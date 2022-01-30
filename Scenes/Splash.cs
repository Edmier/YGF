using Godot;
using System;

public class Splash : Node
{
    Sprite _img;
    public override void _Ready() {
        GetNode<CanvasLayer>("CanvasLayer").Layer = 2;
        _img = GetNode<Sprite>("CanvasLayer/ColorRect/Sprite");
        _img.Modulate = new Color(1, 1, 1, 0.1f);
    }

    public override void _Process(float delta) {
        if (_img.Modulate.a < 1) {
            Color color = new Color(1, 1, 1, _img.Modulate.a + 0.005f);
            _img.Modulate = color;
        }
    }

    public void _on_Timer_timeout() {
        QueueFree();
    }
}
