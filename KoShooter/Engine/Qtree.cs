using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class Quadtree<T>
{
    private int maxObjectsPerNode;
    private int maxLevels;
    private int level;
    private Rectangle bounds;
    private List<T> objects;
    private Quadtree<T>[] nodes;

    public Quadtree(int maxObjectsPerNode, int maxLevels, int level, Rectangle bounds)
    {
        this.maxObjectsPerNode = maxObjectsPerNode;
        this.maxLevels = maxLevels;
        this.level = level;
        this.bounds = bounds;
        this.objects = new List<T>();
        this.nodes = new Quadtree<T>[4];
    }

    public void Clear()
    {
        objects.Clear();

        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] != null)
            {
                nodes[i].Clear();
                nodes[i] = null;
            }
        }
    }

    private void Split()
    {
        int subWidth = bounds.Width / 2;
        int subHeight = bounds.Height / 2;
        int x = bounds.X;
        int y = bounds.Y;

        nodes[0] = new Quadtree<T>(maxObjectsPerNode, maxLevels, level + 1, new Rectangle(x + subWidth, y, subWidth, subHeight));
        nodes[1] = new Quadtree<T>(maxObjectsPerNode, maxLevels, level + 1, new Rectangle(x, y, subWidth, subHeight));
        nodes[2] = new Quadtree<T>(maxObjectsPerNode, maxLevels, level + 1, new Rectangle(x, y + subHeight, subWidth, subHeight));
        nodes[3] = new Quadtree<T>(maxObjectsPerNode, maxLevels, level + 1, new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight));
    }

    private int GetIndex(Rectangle rect)
    {
        int index = -1;
        double verticalMidpoint = bounds.X + (bounds.Width / 2);
        double horizontalMidpoint = bounds.Y + (bounds.Height / 2);

        bool topQuadrant = rect.Y < horizontalMidpoint && rect.Y + rect.Height < horizontalMidpoint;
        bool bottomQuadrant = rect.Y > horizontalMidpoint;

        if (rect.X < verticalMidpoint && rect.X + rect.Width < verticalMidpoint)
        {
            if (topQuadrant)
                index = 1;
            else if (bottomQuadrant)
                index = 2;
        }
        else if (rect.X > verticalMidpoint)
        {
            if (topQuadrant)
                index = 0;
            else if (bottomQuadrant)
                index = 3;
        }

        return index;
    }

    public void Insert(T item, Rectangle rect)
    {
        if (nodes[0] != null)
        {
            int index = GetIndex(rect);

            if (index != -1)
            {
                nodes[index].Insert(item, rect);
                return;
            }
        }

        objects.Add(item);

        if (objects.Count > maxObjectsPerNode && level < maxLevels)
        {
            if (nodes[0] == null)
                Split();

            int i = 0;
            while (i < objects.Count)
            {
                int index = GetIndex(rect);

                if (index != -1)
                    nodes[index].Insert(objects[i], rect);
                else
                {
                    // Если объект не попал в квадрант, оставляем его в текущем узле
                }

                objects.RemoveAt(i);
            }
        }
    }

    public List<T> Retrieve(Rectangle rect)
    {
        List<T> result = new List<T>();
        int index = GetIndex(rect);

        if (index != -1 && nodes[0] != null)
        {
            result.AddRange(nodes[index].Retrieve(rect));
        }

        result.AddRange(objects);

        return result;
    }
}