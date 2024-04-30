using System.Collections.Generic;
using cse3902.Interfaces;

namespace cse3902.Bossfight;

public class BossfightLevel
{
    public BossfightPlayer player;
    public List<IBossfightProjectile> projectiles;
}