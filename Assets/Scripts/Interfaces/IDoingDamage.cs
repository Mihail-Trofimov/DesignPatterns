using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IDoingDamage
    {
        int DamageDealt { get; set; }
    }
}