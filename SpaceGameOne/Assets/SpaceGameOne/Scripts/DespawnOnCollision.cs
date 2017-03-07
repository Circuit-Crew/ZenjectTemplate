using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class DespawnOnCollision : MonoBehaviour
    {
        public bool Despawn;
        public string[] ValidTags;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (var validTag in ValidTags)
            {
               // if (collision.gameObject.CompareTag(validTag))

            }
        }
    }
}