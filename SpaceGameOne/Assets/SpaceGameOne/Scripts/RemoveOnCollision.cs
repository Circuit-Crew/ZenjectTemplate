using UnityEngine;

namespace SpaceGameOne
{
    public class RemoveOnCollision : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("SystemCenter"))
                Destroy(collision.gameObject);
        }
    }
}