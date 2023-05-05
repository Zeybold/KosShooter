using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Player
{
    public Texture2D modelCharacter;
    public Vector2 positionCharacter;
    public float velocity = 2;
    public float rotation = 0;
    public Player()
    {
        modelCharacter = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/TexturePlayer");
        positionCharacter = new Vector2(100, 100);
    }

    public void Update()
    {
        MovePlayer();
        RotationPlayer();
    }

    private void MovePlayer()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            positionCharacter.Y-=velocity;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
            positionCharacter.X-=velocity;
        if (Keyboard.GetState().IsKeyDown(Keys.S))
            positionCharacter.Y+=velocity;
        if (Keyboard.GetState().IsKeyDown(Keys.D))
            positionCharacter.X+=velocity;
    }

    private void RotationPlayer()
    {
        var mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        var direction = Vector2.Normalize(mousePosition - positionCharacter); // calculate the direction vector from player to target
        var angle = (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI/2;
        rotation =  angle;
    }

    public void Draw()
    {
        Configurations.SpriteBatch.Draw(modelCharacter,
            new Rectangle((int)positionCharacter.X, (int)positionCharacter.Y,
                64, 64), null, Color.White, rotation, 
            new Vector2(modelCharacter.Width/2,modelCharacter.Height/2),SpriteEffects.None,0);
    }
}