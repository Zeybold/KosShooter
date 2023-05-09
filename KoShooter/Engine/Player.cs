using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Player : Entity
{
    public Player()
    {
        Texture = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/TexturePlayer");
        Position = new Vector2(100, 100);
        Velocity = 3;
    }
    private void MovePlayer()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            Position.Y-=Velocity;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
            Position.X-=Velocity;
        if (Keyboard.GetState().IsKeyDown(Keys.S))
            Position.Y+=Velocity;
        if (Keyboard.GetState().IsKeyDown(Keys.D))
            Position.X+=Velocity;
    }

    private void RotationPlayer()
    {
        // calculate the direction vector from player to target
        var mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        var direction = Vector2.Normalize(mousePosition - Position);
        var angle = (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI/2;
        Rotation = angle;
    }
    public override void Update(GameTime gameTime)
    {
        MovePlayer();
        RotationPlayer();
    }
}