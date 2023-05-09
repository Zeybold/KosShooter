using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public static class EntityProcessing
{
    private static readonly List<Entity> Entities = new();
    public static void Add(Entity entity)
    {
        Entities.Add(entity);
    }
    public static void Update(GameTime gameTime)
    {
        foreach (var entity in Entities)
            entity.Update(gameTime);
    }
    public static void Draw()
    {
        foreach (var entity in Entities)
            entity.Draw();
    }
}