using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text _coinCountText;
    [SerializeField] private TemplateCheckerOnEntering _checker;

    private int _coinsCount = 0;

    private void OnEnable()
    {
        _checker.OnCoinCollected += AddCoin;
    }

    private void OnDisable()
    {
        _checker.OnCoinCollected += AddCoin;
    }

    private void AddCoin()
    {
        _coinsCount++;
        ShowCoinsCount(_coinsCount);
    }

    private void ShowCoinsCount(int coins)
    {
        _coinCountText.text = coins.ToString();
    }
}
