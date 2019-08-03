using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsCursor : MonoBehaviour
{
    [SerializeField]
    Camera Cam;

    [SerializeField]
    Transform GunOrigin;

    void LookTowardsMouse()
    {
        Vector2 dir = Cam.ScreenToWorldPoint(Input.mousePosition) - GunOrigin.position;

        GunOrigin.right = dir.normalized;
    }

    private void Update()
    {
        LookTowardsMouse();
    }
}
