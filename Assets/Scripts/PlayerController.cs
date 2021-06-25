using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private int lives = 3;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI pointsText;

    
    private float _points = 0;
    private Rigidbody _pacmanRb;
    private GameManager _gameManager;

    private void Start()
    {
        _pacmanRb = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        
        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        _pacmanRb.AddForce(movementSpeed * Time.deltaTime * movement);
        
        if (lives == 0)
        {
            Debug.Log("GAME OVER!!!");
            _pacmanRb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            UpdatePoints(5);
            Destroy(other.gameObject);
            StartCoroutine(_gameManager.PowerUpActive());
        }else if (other.gameObject.CompareTag("Ghost"))
        {
            if (GameManager.IsPowerUpActive)
            {
                UpdatePoints(15);
                other.gameObject.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                LoseLife();
                transform.position = Vector3.zero;
                _pacmanRb.velocity = Vector3.zero;
            }

        }else if (other.gameObject.CompareTag("Coin"))
        {
            PickupCoin(1);
            Destroy(other.gameObject);
        }
    }

    private void UpdatePoints(float points)
    {
        _points += points;
        pointsText.text = "Score: " + points;
    }

    private void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }

    private void PickupCoin(float value)
    {
        _gameManager.Coins += value;
        _gameManager.CoinsText.text = "Coins: " + _gameManager.Coins;
    }
}
