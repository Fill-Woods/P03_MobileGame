using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Swipe Settings")]
    [SerializeField] private float _minSwipeDistance = 50f; // Minimum distance (in pixels) for a swipe to count

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private bool _isSwipeDetected = false;

    public bool TouchSwipeLeft { get; private set; }
    public bool TouchSwipeRight { get; private set; }
    public bool TouchSwipeUp { get; private set; }
    public bool TouchSwipeDown { get; private set; }

    private void Update()
    {
        ResetSwipes();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    _isSwipeDetected = true;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    // Optional: you can track movement if you want early detection
                    break;

                case TouchPhase.Ended:
                    if (_isSwipeDetected)
                    {
                        _endTouchPosition = touch.position;
                        DetectSwipe();
                        _isSwipeDetected = false;
                    }
                    break;
            }
        }
    }

    private void ResetSwipes()
    {
        TouchSwipeLeft = TouchSwipeRight = TouchSwipeUp = TouchSwipeDown = false;
    }

    private void DetectSwipe()
    {
        Vector2 swipeDelta = _endTouchPosition - _startTouchPosition;

        if (swipeDelta.magnitude < _minSwipeDistance)
            return; // Ignore tiny swipes

        float x = swipeDelta.x;
        float y = swipeDelta.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
                TouchSwipeRight = true;
            else
                TouchSwipeLeft = true;
        }
        else
        {
            if (y > 0)
                TouchSwipeUp = true;
            else
                TouchSwipeDown = true;
        }
    }
}
