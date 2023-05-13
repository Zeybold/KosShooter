using System;
using System.Net.Mime;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public class InputData
{
    public void MovePlayer()
    {
        var direction = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            direction.Y--;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
            direction.X--;
        if (Keyboard.GetState().IsKeyDown(Keys.S))
            direction.Y++;
        if (Keyboard.GetState().IsKeyDown(Keys.D))
            direction.X++;
    }
    
}