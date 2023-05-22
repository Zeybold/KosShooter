using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Enemy : Entity,IMovement
{
    public float HP; 
    public Enemy(Vector2 position)
    {
        Texture = TextureSource.Enemy;
        Position = position;
        Velocity = 150;
        HP = 100;
    }
    public override void Update(GameTime gameTime)
    {
        Move(gameTime);
        FindPlayer();
        CollisionUpdate();
        if (HP<=0)
            isExists = false;
    }
    
    private void FindPlayer()
    {
        var mousePosition = Player.Creature.GetPositionEntity();
        var direction = Vector2.Normalize(mousePosition - Position);
        var angle = (float)Math.Atan2(direction.Y, direction.X);
        Rotation = angle+(float)Math.PI/2;
    }

    public void Move(GameTime gameTime)
    {
        var positionPlayer = Player.Creature.GetPositionEntity();
        var direction = Vector2.Normalize(positionPlayer - Position);
        Position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}