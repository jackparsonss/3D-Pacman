using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int pointValue = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController pacman = other.GetComponent<PlayerController>();
            pacman.ConsumePowerUp(pointValue);
            Destroy(gameObject);
        }
    }
}
