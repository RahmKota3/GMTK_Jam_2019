using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTracker : MonoBehaviour
{
    PlayerStats stats;

    void HpChange()
    {
        PlayerPrefs.SetInt("Health", stats.CurrentHp);
    }
    
    void Setup(Scene current, Scene next)
    {
        stats = FindObjectOfType<PlayerStats>();
        stats.OnHpChanged += HpChange;
        
        stats.SetHealth(PlayerPrefs.GetInt("Health"));
    }

    private void Awake()
    {
        SceneManager.activeSceneChanged += Setup;
    }
}
