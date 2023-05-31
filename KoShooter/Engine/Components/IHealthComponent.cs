using SharpDX;

namespace KosShooter;

public interface IHealthComponent
{
    public float MaxHp { get; protected set;}
    public float CurrentHp{ get; protected set; }
    public void TakeDamage(float damage);
    public void Heal(float heal);
}