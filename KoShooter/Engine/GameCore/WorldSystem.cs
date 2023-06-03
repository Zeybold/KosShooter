using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using KosShooter.Engine;
using KosShooter.Engine.UI;
using KosShooter.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class WorldSystem
{
    public static readonly Map Map = new Map();
    public static Matrix Camera { get; private set; }
    private static float _timerSpawn = 5f;
    public WorldSystem()
    {
        Configurations.MapBounds(Map.MapSize,Map.TileSize);
        Player.Creature.SetPosition(new Vector2(500,500));
        EntityProcessing.Add(Player.Creature);
        Player.Creature.SetBounds(Map.MapSize, Map.TileSize);
        Mouse.SetCursor(MouseCursor.FromTexture2D(Configurations.ContentGame.Load<Texture2D>("TextureGames/Cursor/aim"),10,10));
        PlayerSkills.ResetCharacter();
        
    }
    private void CalculateTranslation()
    {
        var dx = Configurations.ScreenWidth / 2 - Player.Creature.Position.X;
        dx = MathHelper.Clamp(dx, -Map.MapSize.X + Configurations.ScreenWidth + Map.TileSize.X / 2, Map.TileSize.X / 2);
        var dy = Configurations.ScreenHeight / 2 - Player.Creature.Position.Y;
        dy = MathHelper.Clamp(dy, -Map.MapSize.Y + Configurations.ScreenHeight + Map.TileSize.Y / 2, Map.TileSize.Y / 2);
        Camera = Matrix.CreateTranslation(dx, dy, 0f);
    }
    public void Update()
    {
        _timerSpawn -= Configurations.Time;
        if (_timerSpawn <= 0)
        {
            _timerSpawn = 5f;
            SpawnEnemy((EnemyStatus)new Random().Next(0,2));
            SpawnHelp();
        }
        InputDataComponent.RegistrationKey();
        EntityProcessing.Update();
        CalculateTranslation();
        PlayerInterface.Update();
    }

    public void Draw()
    {
        Configurations.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
            null, null, null, null, Camera);
        Map.Draw();
        EntityProcessing.Draw();
        Configurations.SpriteBatch.End();
        Configurations.SpriteBatch.Begin();
        PlayerInterface.Draw();
        Configurations.SpriteBatch.End();
    }

    private void SpawnEnemy(EnemyStatus enemyStatus)
    {
        for (var i = 0; i < 10; i++)
        {
            Enemy em = null;
            var rnd = new Random();
            switch (enemyStatus)
            {
                case EnemyStatus.Bug:
                    em = new Bug(new Vector2(rnd.Next(0, Map.MapSize.X), rnd.Next(0, Map.MapSize.Y)));
                    break;
                case EnemyStatus.Reptile:
                    em = new Reptile(new Vector2(rnd.Next(0, Map.MapSize.X), rnd.Next(0, Map.MapSize.Y)));
                    break;
                case EnemyStatus.Daemon:
                    em = new Daemon(new Vector2(rnd.Next(0, Map.MapSize.X), rnd.Next(0, Map.MapSize.Y)));
                    break;
            }
            em.SetBounds(Map.MapSize, Map.TileSize);
            EntityProcessing.Add(em);
        }
    }
    private void SpawnHelp()
    {
        for (var i = 0; i < 5; i++)
        {
            var rnd = new Random();
            var aid = new AiItemAidKit();
            aid.GetPosition(new Vector2(rnd.Next(0, Map.MapSize.X), rnd.Next(0, Map.MapSize.Y)));
            EntityProcessing.Add(aid);
            var wep = new AiItemWeaponAmmunition();
            wep.GetPosition(new Vector2(rnd.Next(0, Map.MapSize.X), rnd.Next(0, Map.MapSize.Y)));
            EntityProcessing.Add(wep);
        }
    }
}