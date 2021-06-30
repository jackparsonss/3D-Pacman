using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.PickupCoin(value);
        Destroy(gameObject);
        
    }
}
