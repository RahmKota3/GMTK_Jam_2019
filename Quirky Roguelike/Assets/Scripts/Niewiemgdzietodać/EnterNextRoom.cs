using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNextRoom : MonoBehaviour
{
    private bool isOpened;

    void Start()
    {
        isOpened = true;
    }

    public void Close()
    {
        isOpened = false;
    }

    public void Open()
    {
        isOpened = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpened == true)
            {
                Debug.Log("dszwi");
                SceneManagerScript.Instance.Load(SceneManagerScript.Instance.RandomScene());
            }
            else
            {
                Debug.Log("The door is closed");
            }
        }
    }
}
