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

abstract class Weapon
{
    protected Texture2D Texture;
    private Vector2 Size => new(Texture.Width, Texture.Height);
    public Vector2 Position;
    public int Damage;
    
    public abstract void Update(GameTime gameTime);

    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(Texture, Position, null, Configurations.BaseColor, 0, Size/2,1, 0, 0);
    }
}