using Godot;
using System;

public class Splash : Node
{
    Sprite _img;
    ColorRect _color;

    private bool appearing = true;

    public override void _Ready() {
        GetNode<CanvasLayer>("CanvasLayer").Layer = 2;

        _img = GetNode<Sprite>("CanvasLayer/ColorRect/Sprite");
        _img.Modulate = new Color(1, 1, 1, 0.1f);

        _color = GetNode<ColorRect>("CanvasLayer/ColorRect");
    }

    public override void _Process(float delta) {
        if (appearing) {
            float Opacity = _img.Modulate.a + (_img.Modulate.a * delta) + 0.005f;
            Color color = new Color(1, 1, 1, Opacity);
            _img.Modulate = color;

            appearing = !(Opacity >= 1);
        } else if (_img.Modulate.a > 0) {
            Color color = new Color(1, 1, 1, _img.Modulate.a + (_img.Modulate.a * delta) - 0.02f);
            _img.Modulate = color;
            _color.Color = color;
        } else {
            QueueFree();
        }
    }

    public void _on_Timer_timeout() {
        QueueFree();
    }
}
