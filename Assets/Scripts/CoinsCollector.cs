using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private Text _coinCountText;
    private int _coinsCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            AddCoin();
            ShowCoinsCount(_coinsCount);
            Destroy(other.gameObject);
        }
    }

    private void AddCoin()
    {
        _coinsCount++;
    }

    private void ShowCoinsCount(int coins)
    {
        _coinCountText.text = coins.ToString();
    }
}
