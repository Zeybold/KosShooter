using System;
using System.Net.Mime;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Bullet : Entity
{
    public Vector2 Traectoia = Vector2.Zero;
    public Bullet()
    {
        Position = Player.Creature.GetPositionEntity();
        Rotation = Player.Creature.GetRotationEntity();
        Velocity = 10;
        Texture = TextureSource.Bullet;
    }
    
    public override void Update(GameTime gameTime)
    {
        Position.X += (float)(Velocity*Math.Cos(Rotation-Math.PI/2));
        Position.Y += (float)(Velocity*Math.Sin(Rotation-Math.PI/2));
        if (Position.X > Configurations.ScreenWidth || Position.Y > Configurations.ScreenHeight)
            isExists = false;
    }
}