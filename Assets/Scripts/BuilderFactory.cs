using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static class BuilderFactory
    {
        public static Ammunition BuidBlaster
        {
            get
            {
                const string name = Constant.NAME_BLASTER;

                const bool isTrigger = true;
                Vector2 offset = new Vector2(0.03f, 0f);
                Vector2 size = new Vector2(0.2f, 0.1f);

                const float mass = 0.1f;
                const float linearDrag = 0f;
                const float angularDrag = 0f;
                const float gravityDrag = 0f;

                Sprite sprite = Resources.Load<Sprite>(Constant.SPRITE_PLASMA);

                const float lifeTime = 2.5f;
                const int damageDealt = 10;

                GameObject gameObject = new GameObject().
                SetName(name).
                AddBoxCollider2D(isTrigger, offset, size).
                AddRigidbody2D(mass, linearDrag, angularDrag, gravityDrag).
                AddSprite(sprite).
                AddAmmunition(lifeTime, damageDealt);

                return gameObject.GetComponent<Ammunition>();
            }
        }
    }
}