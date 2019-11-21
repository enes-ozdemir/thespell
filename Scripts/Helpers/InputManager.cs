using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputDirection
{
    HORIZONTAL,
    VERTICAL
}

public class InputManager{

	public static bool PressedKey(KeyCode code)
    {
        return Input.GetKeyDown(code);
    }

    public static bool HoldingKey(KeyCode code)
    {
        return Input.GetKey(code);
    }

    public static bool ReleaseKey(KeyCode code)
    {
        return Input.GetKeyUp(code);
    }

    public static bool LeftClickDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    public static bool RightClickDown()
    {
        return Input.GetMouseButtonDown(1);
    }

    public static bool RightClickHold()
    {
        return Input.GetMouseButton(1);
    }

    public static bool LeftClickHold()
    {
        return Input.GetMouseButton(1);
    }

    public static float InputAxis(InputDirection typ) { 
        switch(typ)
        {
            case InputDirection.HORIZONTAL:
                return Input.GetAxis("Horizontal");

            case InputDirection.VERTICAL:
                return Input.GetAxis("Vertical");

            default:
                return 0f;
        }
    }

}
