using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public static class InputDataComponent
{
    private static KeyboardState _currentKey;
    private static KeyboardState _previousKey;
    private static MouseState _mouseState;

    public static void RegistrationKey()
    {
        _previousKey = _currentKey;
        _currentKey = Keyboard.GetState();
        _mouseState = Mouse.GetState();
    }

    public static bool IsLeftMouseClicked()
    {
        return _mouseState.LeftButton == ButtonState.Pressed;
    }
    public static int MouseWheelBeScrolled()
    {
        return _mouseState.ScrollWheelValue;
    }
    public static bool KeyBePressed(Keys key)
    {
        return _currentKey.IsKeyDown(key) && _previousKey.IsKeyUp(key);
    }

    public static float GetAngleRotation()
    {
        var mousePosition = new Vector2(_mouseState.X, _mouseState.Y);
        var direction = Vector2.Normalize(mousePosition - Player.Creature.GetPositionEntity());
        return (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI/2;
    }
    public static Vector2 GetMovement()
    {
        var direction = Vector2.Zero;
        if (_currentKey.IsKeyDown(Keys.W))
            direction.Y--;
        if (_currentKey.IsKeyDown(Keys.A))
            direction.X--;
        if (_currentKey.IsKeyDown(Keys.S))
            direction.Y++;
        if (_currentKey.IsKeyDown(Keys.D))
            direction.X++;
        return direction;
    }
}