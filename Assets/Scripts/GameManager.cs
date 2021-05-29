using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float coins;

    public TextMeshProUGUI CoinsText { get => coinsText; set => coinsText = value; }
    public float Coins { get => coins; set => coins = value; }

}
