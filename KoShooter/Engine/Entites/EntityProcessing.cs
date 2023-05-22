using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D11;

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