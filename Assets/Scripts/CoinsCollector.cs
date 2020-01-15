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
        AddCoin(other);
    }

    private void AddCoin(Collider2D coin)
    {

        if (coin.GetComponent<Coin>())
        {
            _coinsCount++;
            ShowCoinsCount(_coinsCount);
            Destroy(coin.gameObject);
        }
    }

    private void ShowCoinsCount(int coins)
    {
        _coinCountText.text = coins.ToString();
    }
}
