using System;
using System.Net.Mime;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace KosShooter;

public class Bullet : Entity
{
    
    public Bullet(Vector2 position, float velocity, float tochnost)
    {
        Position = position;
        Velocity = velocity;
        Texture = TextureSource.Bullet;
        var GreatRandom = new Random();
        Rotation = RandomUtil.NextFloat(GreatRandom,-tochnost,tochnost)+Player.Creature.GetRotationEntity();

    }
    
    public override void Update(GameTime gameTime)
    {
        Position.X += (float)(Velocity*Math.Cos(Rotation-Math.PI/2));
        Position.Y += (float)(Velocity*Math.Sin(Rotation-Math.PI/2));
        if (Position.X > Configurations.ScreenWidth || Position.Y > Configurations.ScreenHeight)
            isExists = false;
    }
}