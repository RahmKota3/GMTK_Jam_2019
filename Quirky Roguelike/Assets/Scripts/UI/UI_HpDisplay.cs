using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_HpDisplay : MonoBehaviour
{
    [SerializeField]
    PlayerStats playerStats;

    [SerializeField]
    string hpPrefix = "Life: ";

    Text hpText;

    void UpdateHpText()
    {
        hpText.text = hpPrefix + playerStats.CurrentHp.ToString();
    }

    private void Awake()
    {
        hpText = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateHpText();
        playerStats.OnHpChanged += UpdateHpText;
    }
}
