using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter.Engine;

public class Title
{
    private readonly Texture2D _texture;
    public Vector2 Position { get; protected set; }
    public Vector2 Origin { get; protected set; }


    public Title(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        Position = position;
        Origin = new(_texture.Width / 2, _texture.Height / 2);
    }
    
    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}