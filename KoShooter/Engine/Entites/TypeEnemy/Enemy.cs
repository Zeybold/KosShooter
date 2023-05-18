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
    public float HP;
    public Enemy(Vector2 position)
    {
        Texture = TextureSource.Enemy;
        Position = position;
        Velocity = 3;
        HP = 150;
    }
    public override void Update(GameTime gameTime)
    {
        FindPlayer();
        //NonsensicalMove();
        CollisionUpdate();
        if (HP<=0)
            isExists = false;
    }
    
    private void FindPlayer()
    {
        var mousePosition = Player.Creature.GetPositionEntity();
        var direction = Vector2.Normalize(mousePosition - Position);
        var angle = (float)Math.Atan2(direction.Y, direction.X);
        Position += new Vector2(direction.X, direction.Y)*Velocity;
        Rotation = angle+(float)Math.PI/2;
    }

    private void NonsensicalMove()
    {
        
        Position.X += Velocity * (float)Math.Cos(Rotation - Math.PI / 2);
        Position.Y += Velocity * (float)Math.Cos(Rotation - Math.PI / 2);
    }

}