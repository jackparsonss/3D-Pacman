using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private int lives = 3;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI pointsText;
    
    private float _points;
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
    }

    private void Die()
    {
        Debug.Log("GAME OVER!!!");
        _pacmanRb.isKinematic = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            UpdateAndCheckPoints(1);
            Destroy(other.gameObject);
        }
    }

    public void ConsumePowerUp(int points)
    {
        UpdateAndCheckPoints(points);
        _gameManager.StartPowerUp();
    }

    public void ConsumeGhost(int points)
    {
        UpdateAndCheckPoints(points);
    }

    public void GetEaten()
    {
        LoseLifeAndCheckDeath();
        transform.position = Vector3.zero;
        _pacmanRb.velocity = Vector3.zero;
    }

    private void UpdateAndCheckPoints(int points)
    {
        UpdatePoints(points);
        if (_points == _gameManager.totalLevelPoints)
        {
            Debug.Log("LEVEL COMPLETE!!");
        }
    }

    private void UpdatePoints(int points)
    {
        _points += points;
        pointsText.text = "Score: " + _points;
    }

    private void LoseLifeAndCheckDeath()
    {
        LoseLife();
        if (lives == 0)
        {
            Die();
        }
    }

    private void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }
}
