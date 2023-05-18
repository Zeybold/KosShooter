using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class WorldSystem
{
    public WorldSystem()
    {
        EntityProcessing.Add(Player.Creature);
        var rnd = new Random();
        for (var i = 0; i < 1000; i++)
        {
            EntityProcessing.Add(new Enemy(new Vector2(new Random().Next(0,Configurations.ScreenWidth),new Random().Next(0,Configurations.ScreenHeight))));
        }

        Mouse.SetCursor(MouseCursor.FromTexture2D(Configurations.ContentGame.Load<Texture2D>("TextureGames/Cursor/aim"),10,10));
    }

    public void Update(GameTime gameTime)
    {
        EntityProcessing.Update(gameTime);
    }

    public void Draw()
    {
        EntityProcessing.Draw();
    }
}