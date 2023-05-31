using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using KosShooter.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class WorldSystem
{
    public static readonly Map Map = new Map();
    public static Matrix _translation;
    public WorldSystem()
    {
        Configurations.MapBounds(Map.MapSize,Map.TileSize);
        EntityProcessing.Add(new Pistol());
        EntityProcessing.Add(new Shootgun(new Vector2(300,350)));
        Player.Creature.SetPosition(new Vector2(500,500));
        EntityProcessing.Add(Player.Creature);
        Player.Creature.SetBounds(Map.MapSize, Map.TileSize);
        var rnd = new Random();
        /*for (var i = 0; i < 10; i++)
        {
            EntityProcessing.Add(new Enemy(new Vector2(rnd.Next(0,Configurations.ScreenWidth),rnd.Next(0,Configurations.ScreenHeight))));
        }*/
        Mouse.SetCursor(MouseCursor.FromTexture2D(Configurations.ContentGame.Load<Texture2D>("TextureGames/Cursor/aim"),10,10));
        PlayerSkills.ResetCharacter();
        
    }
    private void CalculateTranslation()
    {
        var dx = (Configurations.ScreenWidth / 2) - Player.Creature.Position.X;
        dx = MathHelper.Clamp(dx, -Map.MapSize.X + Configurations.ScreenWidth + (Map.TileSize.X / 2), Map.TileSize.X / 2);
        var dy = (Configurations.ScreenHeight / 2) - Player.Creature.Position.Y;
        dy = MathHelper.Clamp(dy, -Map.MapSize.Y + Configurations.ScreenHeight + (Map.TileSize.Y / 2), Map.TileSize.Y / 2);
        _translation = Matrix.CreateTranslation(dx, dy, 0f);
    }
    public void Update()
    {
        InputDataComponent.RegistrationKey();
        EntityProcessing.Update();
        PlayerInterface.Update();
        CalculateTranslation();
    }

    public void Draw()
    {
        Configurations.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
            null, null, null, null, _translation);
        Map.Draw();
        EntityProcessing.Draw();
        Configurations.SpriteBatch.End();
        Configurations.SpriteBatch.Begin();
        PlayerInterface.Draw();
        Configurations.SpriteBatch.End();
    }
}