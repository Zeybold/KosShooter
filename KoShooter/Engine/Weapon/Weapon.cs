using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace KosShooter;

public class Weapon
{
    protected Texture2D Texture;
    private Vector2 Size => new(Texture.Width, Texture.Height);
    public Vector2 Position;
    public Weapon()
    {
        Texture = TextureSource.Gun1;
        Position = new Vector2(Configurations.ScreenWidth/2, Configurations.ScreenHeight/2);
    }
    public virtual void Update(GameTime gameTime)
    {
        
    }

    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(Texture, Position, null, Configurations.BaseColor, 0, Size/2,1, 0, 0);
    }
}