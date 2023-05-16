using System;
using System.Collections.Generic;
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
            _entities = _entities.Where(x => x.isExists).ToList();
        }
    }
    public static void Draw()
    {
        foreach (var entity in _entities)
                entity.Draw();
    }
}