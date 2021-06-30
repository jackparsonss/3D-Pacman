using UnityEngine;

namespace Ghosts
{
    public class Ghost : MonoBehaviour
    {
        [SerializeField] private int pointValue = 5;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerController pacman = other.GetComponent<PlayerController>();
                EatOrGetEaten(pacman);
            }
        }

        private void EatOrGetEaten(PlayerController pacman)
        {
            if (GameManager.IsPowerUpActive)
            {
                pacman.ConsumeGhost(pointValue);
                transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                pacman.GetEaten();
            }
        }
    }
}
