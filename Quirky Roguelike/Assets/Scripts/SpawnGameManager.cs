using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameManagerPrefab;

    [SerializeField]
    Quirks quirkToActivate = Quirks.None;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("GameManager") == null)
        {
            Instantiate(gameManagerPrefab, Vector3.zero, Quaternion.identity);
        }

        QuirkManager.Instance.ActiveQuirk = quirkToActivate;
    }
}
