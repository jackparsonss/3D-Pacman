using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static bool IsPowerUpActive = false;
    
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float coins;

    private GameObject[] _ghosts;

    private void Start()
    {
        _ghosts = GameObject.FindGameObjectsWithTag("Ghost");
    }

    public void StartPowerUp()
    {
        StartCoroutine(PowerUpActive());
    }
    public void PickupCoin(float value)
    {
        coins += value;
        coinsText.text = "Coins: " + coins;
    }
    private IEnumerator PowerUpActive()
    {
        IsPowerUpActive = true;
        ChangeGhostsColor(Color.blue);

        yield return new WaitForSeconds(5);
        
        IsPowerUpActive = false;
        ChangeGhostsColor(Color.red);
    }

    private void ChangeGhostsColor(Color color)
    {
        foreach (GameObject ghost in _ghosts)
        {
            ghost.GetComponent<Renderer>().material.color = color;
        }
    }

}
