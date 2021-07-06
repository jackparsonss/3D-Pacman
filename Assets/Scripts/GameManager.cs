using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static bool IsPowerUpActive = false;
    
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float coins;
    [SerializeField] private Material _greenGhostMaterial;
    [SerializeField] private Material _blueGhostMaterial;

    private GameObject[] _ghosts;
    
    private void Start()
    {
        _ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        // _greenGhostMaterial = Resources.Load("Materials/GreenGhost", typeof(Material)) as Material;
        // _blueGhostMaterial = Resources.Load("Materials/BlueGhost", typeof(Material)) as Material;
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
