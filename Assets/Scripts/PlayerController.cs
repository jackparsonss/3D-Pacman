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
        
        if (lives == 0)
        {
            Debug.Log("GAME OVER!!!");
            _pacmanRb.isKinematic = true;
        }
    }

    public void ConsumePowerUp(int points)
    {
        UpdatePoints(points);
        _gameManager.StartPowerUp();
    }

    public void ConsumeGhost(int points)
    {
        UpdatePoints(points);
    }

    public void GetEaten()
    {
        LoseLife();
        transform.position = Vector3.zero;
        _pacmanRb.velocity = Vector3.zero;
    }

    private void UpdatePoints(float points)
    {
        _points += points;
        pointsText.text = "Score: " + _points;
    }

    private void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }
}
