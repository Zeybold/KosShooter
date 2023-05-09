using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Enemy : Entity
{
    public Enemy()
    {
        Texture = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/TexturePlayer");
        Position = new Vector2(150, 150);
        Velocity = 3;
    }
    public override void Update(GameTime gameTime)
    {
        FindPlayer();
    }
    private void FindPlayer()
    {
        
    }
}