using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public static class InputData
{
    private static KeyboardState _currentKey;
    private static KeyboardState _previousKey;

    public static void RegistrationKey()
    {
        _previousKey = _currentKey;
        _currentKey = Keyboard.GetState();
    }

    public static void FreezingTime()
    {
        if (_currentKey.IsKeyDown(Keys.T) &&
            _previousKey.IsKeyUp(Keys.T))
        {
            Configurations.isFreezeTime = !Configurations.isFreezeTime;
        }
    }

    public static float GetAngleRotation()
    {
        var mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
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