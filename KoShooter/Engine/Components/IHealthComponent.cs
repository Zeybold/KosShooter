using SharpDX;

namespace KosShooter;

public interface IHealthComponent
{
    public void TakeDamage(float damage);
    public void Heal(float heal);
}