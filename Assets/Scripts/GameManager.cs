using System;
using System.Collections;
using Ghosts;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float coins;

    private GameObject[] _ghosts;

    public TextMeshProUGUI CoinsText { get => coinsText; set => coinsText = value; }
    public float Coins { get => coins; set => coins = value; }

    private void Start()
    {
        _ghosts = GameObject.FindGameObjectsWithTag("Ghost");
    }

    public IEnumerator PowerUpActive()
    {
        ChangeGhostsColor(Color.blue);

        yield return new WaitForSeconds(5);

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
