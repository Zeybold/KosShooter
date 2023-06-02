using System.Collections.Generic;
using KosShooter;
using KosShooter.Items;
using SharpDX;
using Vector2 = Microsoft.Xna.Framework.Vector2;

public static class EntityProcessing
{
    private static HashSet<Entity> _entities = new HashSet<Entity>();
    private static HashSet<Entity> _addEntities = new HashSet<Entity>();
    private static object _lockObject = new object();

    public static void Add(Entity entity)
    {
        lock (_lockObject)
        {
            _addEntities.Add(entity);
        }
    }

    public static void Update()
    {
        lock (_lockObject)
        {
            foreach (var entity in _entities)
                entity.Update();

            foreach (var entity in _addEntities)
                _entities.Add(entity);

            HandleCollisions();

            _addEntities.Clear();
            _entities.RemoveWhere(entity => !entity.IsExist());
        }
    }

    public static void Draw()
    {
        lock (_lockObject)
        {
            foreach (var entity in _entities)
                entity.Draw();
        }
    }

    static void HandleCollisions()
    {
        lock (_lockObject)
        {
            foreach (var entityA in _entities)
            {
                foreach (var entityB in _entities)
                {
                    if (entityA == entityB)
                        continue;

                    if (IsCollise(entityA.CollisionRectangle,entityB.CollisionRectangle))
                    {
                        GetCollisionWithBullet(entityA, entityB);
                        GetCollisionWithBullet(entityB, entityA);
                        GetCollisionWithCreations(entityA, entityB);
                        GetCollisionWithItems(entityA, entityB);
                        GetCollisionWithItems(entityB, entityA);
                    }
                }
            }
        }
    }

    static bool IsCollise(Vector2[] a , Vector2[] b)
    {
        if (a[0].X > b[3].X || b[0].X > a[3].X)
            return false;

        if (a[0].Y > b[3].Y || b[0].Y > a[3].Y)
            return false;
        return true;
    }

    private static void GetCollisionWithBullet(Entity entity1, Entity entity2)
    {
        if (entity1 is Bullet && entity2 is Enemy)
        {
            ((Enemy)entity2).TakeDamage(((Bullet)entity1).Damage);
            entity1.Status = GameStatus.NotExist;
        }
    }
    private static void GetCollisionWithCreations(Entity entity1, Entity entity2)
    {
        if (entity1 is Enemy && entity2 is Enemy)
        {
            var dir = 10f*Vector2.Normalize(entity1.Position-
                                            entity2.Position);
            entity1.Impulse(dir);
            entity2.Impulse(-dir);
        }
    }
    private static void GetCollisionWithItems(Entity entity1, Entity entity2)
    {
        if (entity1 is Player && entity2 is Enemy)
        {
            var dir = 10f*Vector2.Normalize(entity1.Position-
                                            entity2.Position);
            (entity2 as Enemy).MakeDamage();
            entity1.Impulse(dir);
            entity2.Impulse(-dir);
        }
    }
}