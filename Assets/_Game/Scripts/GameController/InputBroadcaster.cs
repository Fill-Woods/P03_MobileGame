using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;
    private void Update()
    {
        //NOTE: put better Input Detection here. This code is just for simple example and does not account for new Unity Input System.
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IsTapPressed = true;
                    break;
                case TouchPhase.Ended:
                    IsTapPressed = false;
                    break;
            }
        }
    }
}
