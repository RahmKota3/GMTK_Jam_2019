using UnityEngine;

public static class SpeedCalculator
{
    static float speed = 7f;
    
    public static Vector2 CalculateSpeed()
    {
        Vector2 movement = Vector2.zero;

        switch (QuirkManager.Instance.ActiveQuirk)
        {
            case Quirks.TileMovement:

                break;

            default:
                // TODO: ?Zrobic przyjemniejsze sterowanie jak starczy czasu?

                movement = new Vector2(CalculateHorizontalSpeed(), CalculateVerticalSpeed());
                break;
        }

        return movement;
    }

    static float CalculateVerticalSpeed()
    {
        return InputManager.Instance.VerticalAxis * speed;
    }

    static float CalculateHorizontalSpeed()
    {
        return InputManager.Instance.HorizontalAxis * speed;
    }

}
