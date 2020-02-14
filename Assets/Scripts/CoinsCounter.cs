using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text _coinCountText;
    [SerializeField] private EnvironmentTrigger _trigger;

    private int _coinsCount = 0;

    private void OnEnable()
    {
        _trigger.CoinCollecting += OnCoinCollecting;
    }

    private void OnDisable()
    {
        _trigger.CoinCollecting -= OnCoinCollecting;
    }

    private void OnCoinCollecting()
    {
        _coinsCount++;
        ShowCoinsCount(_coinsCount);
    }

    private void ShowCoinsCount(int coins)
    {
        _coinCountText.text = coins.ToString();
    }
}
