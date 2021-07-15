using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool IsPowerUpActive = false;
    public int totalLevelPoints;
    
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float coins;
    [SerializeField] private Material _greenGhostMaterial;
    [SerializeField] private Material _blueGhostMaterial;

    private GameObject[] _ghosts;
    private int _amountOfPoints;
    private int _amountOfPowerUps;
    
    private void Start()
    {
        _ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        
        _amountOfPoints = GameObject.FindGameObjectsWithTag("Point").Length;
        _amountOfPowerUps = GameObject.FindGameObjectsWithTag("Powerup").Length;
        
        totalLevelPoints = _amountOfPoints + _amountOfPowerUps;
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
        ChangeGhostsColor(_blueGhostMaterial);

        yield return new WaitForSeconds(5);
        
        IsPowerUpActive = false;
        ChangeGhostsColor(_greenGhostMaterial);
    }

    private void ChangeGhostsColor(Material color)
    {
        foreach (GameObject ghost in _ghosts)
        {
            ghost.GetComponent<Renderer>().material = color;
        }
    }

}
