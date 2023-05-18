using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public static class EntityProcessing
{
    private static List<Entity> _entities = new();
    private static List<Entity> _addEntities = new();
    
    public static void Add(Entity entity)
    {
        _addEntities.Add(entity);
    }
    public static void Update(GameTime gameTime)
    {
        lock (_entities)
        {
            foreach (var entity in _entities)
                entity.Update(gameTime);
            foreach (var entity in _addEntities)
                _entities.Add(entity);
            _addEntities.Clear();
            //ToDo Lower String more better
            for (var i = 0; i < _entities.Count; i++)
            {
                for (var j =i; j < _entities.Count; j++)
                {
                    if (IsCollise(_entities[i].CollisionRectangle, _entities[j].CollisionRectangle) && i != j)
                    {
                        if (_entities[i] is Bullet && _entities[j] is Enemy)
                        {
                            _entities[i].isExists=false;
                            (_entities[j] as Enemy).HP -= (_entities[i] as Bullet).Damage;
                        }
                        if (_entities[i] is Enemy && _entities[j] is Bullet)
                        {
                            _entities[j].isExists=false;
                            (_entities[i] as Enemy).HP -= (_entities[j] as Bullet).Damage;
                        }
                    }
                }
            }
            _entities = _entities.Where(x => x.isExists).ToList();
        }
    }
    public static void Draw()
    {
        foreach (var entity in _entities)
                entity.Draw();
    }

    static bool IsCollise(Vector2[] a , Vector2[] b)
    {
        if (a[0].X > b[3].X || b[0].X > a[3].X)
            return false;

        if (a[0].Y > b[3].Y || b[0].Y > a[3].Y)
            return false;

        return true;
    }
}