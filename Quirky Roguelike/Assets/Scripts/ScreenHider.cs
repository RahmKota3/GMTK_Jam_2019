using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHider : MonoBehaviour
{
    [SerializeField]
    GameObject RightHider;
    [SerializeField]
    GameObject LeftHider;

    void ShowRightSide()
    {
        RightHider.SetActive(false);
        LeftHider.SetActive(true);
    }

    void ShowLeftSide()
    {
        RightHider.SetActive(true);
        LeftHider.SetActive(false);
    }

    void DestroyScreenHider()
    {
        InputManager.Instance.OnShootPressed -= ShowLeftSide;
        InputManager.Instance.OnRMBPressed -= ShowRightSide;

        Destroy(gameObject);
    }

    private void Start()
    {
        QuirkManager.Instance.OnQuirkChange += DestroyScreenHider;

        InputManager.Instance.OnShootPressed += ShowRightSide;
        InputManager.Instance.OnRMBPressed += ShowLeftSide;
    }
}
