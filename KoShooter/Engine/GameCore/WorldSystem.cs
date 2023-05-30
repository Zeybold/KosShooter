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
    private readonly Map _map;
    public static Matrix _translation;
    public WorldSystem()
    {
        
        _map = new Map();
        Configurations.MapBounds(_map.MapSize,_map.TileSize);
        EntityProcessing.Add(new Pistol());
        EntityProcessing.Add(new Shootgun(new Vector2(300,350)));
        Player.Creature.SetPosition(new Vector2(500,500));
        EntityProcessing.Add(Player.Creature);
        var rnd = new Random();
        for (var i = 0; i < 10; i++)
        {
            EntityProcessing.Add(new Enemy(new Vector2(rnd.Next(0,Configurations.ScreenWidth),rnd.Next(0,Configurations.ScreenHeight))));
        }
        Mouse.SetCursor(MouseCursor.FromTexture2D(Configurations.ContentGame.Load<Texture2D>("TextureGames/Cursor/aim"),10,10));
        PlayerSkills.ResetCharacter();
        
    }
    private void CalculateTranslation()
    {
        var dx = (Configurations.ScreenWidth / 2) - Player.Creature.Position.X;
        dx = MathHelper.Clamp(dx, -_map.MapSize.X + Configurations.ScreenWidth  + (_map.TileSize.X / 2), _map.TileSize.X / 2);
        var dy = (Configurations.ScreenHeight / 2) - Player.Creature.Position.Y;
        dy = MathHelper.Clamp(dy, -_map.MapSize.Y + Configurations.ScreenHeight + (_map.TileSize.Y / 2), _map.TileSize.Y / 2);
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
        Configurations.SpriteBatch.Begin();
        _map.Draw();
        EntityProcessing.Draw();
        Configurations.SpriteBatch.End();
        Configurations.SpriteBatch.Begin();
        PlayerInterface.Draw();
        Configurations.SpriteBatch.End();
    }
}