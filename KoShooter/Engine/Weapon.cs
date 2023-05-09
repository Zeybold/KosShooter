using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Weapon
{
    protected Texture2D Texture;
    protected Vector2 Position;
    private Vector2 Size => new(Texture.Width, Texture.Height);
    public Weapon()
    {
        Texture = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/TexturePlayer");
    }
    public virtual void Update(GameTime gameTime)
    {
        
    }

    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(Texture, Position, null, Configurations.BaseColor, 0, Size/2,1, 0, 0);
    }
}