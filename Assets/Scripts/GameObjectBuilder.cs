using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static partial class GameObjectBuilder
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;

            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float linearDrag, float angularDrag, float gravityScale)
        {
            Rigidbody2D component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.drag = linearDrag;
            component.angularDrag = angularDrag;
            component.gravityScale = gravityScale;

            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject, bool isTrigger, Vector2 offset, Vector2 size)
        {
            BoxCollider2D component = gameObject.GetOrAddComponent<BoxCollider2D>();
            component.isTrigger = isTrigger;
            component.offset = offset;
            component.size = size;

            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            SpriteRenderer component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;

            return gameObject;
        }

        public static GameObject AddAmmunition(this GameObject gameObject, float lifeTime, int damageDealt)
        {
            Ammunition component = gameObject.GetOrAddComponent<Ammunition>();
            component.LifeTime = lifeTime;
            component.DamageDealt = damageDealt;

            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }

    }
}