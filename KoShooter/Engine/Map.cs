using System;
using System.Collections.Generic;
using System.DirectoryServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter.Engine;

public class Map
{
    //256x256
    private readonly Point _mapTileSize = new(6, 5);
    private readonly Title[,] _tiles;
    public Point TileSize { get; private set; }
    public Point MapSize { get; private set; }

    public Map()
    {
        _tiles = new Title[_mapTileSize.X, _mapTileSize.Y];

        List<Texture2D> textures = new(5);
        for (var i = 1; i < 5; i++)
        {
            textures.Add( Configurations.ContentGame.Load<Texture2D>("TextureGames/Map/tile1"));
        }

        TileSize = new(textures[0].Width, textures[0].Height);
        MapSize = new(TileSize.X * _mapTileSize.X, TileSize.Y * _mapTileSize.Y);

        Random random = new();

        for (int y = 0; y < _mapTileSize.Y; y++)
        {
            for (int x = 0; x < _mapTileSize.X; x++)
            {
                int r = random.Next(0, textures.Count);
                _tiles[x, y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y));
            }
        }
    }

    public void Draw()
    {
        for (int y = 0; y < _mapTileSize.Y; y++)
        {
            for (int x = 0; x < _mapTileSize.X; x++) _tiles[x, y].Draw();
        }
    }
}