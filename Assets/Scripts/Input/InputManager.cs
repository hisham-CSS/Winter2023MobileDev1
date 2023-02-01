using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singelton<InputManager>
{
    #region Actions
    public static event Action<Vector2, float> OnStartTouch;
    public static event Action<Vector2, float> OnEndTouch;
    #endregion

    PlayerControls input;
    // Start is called before the first frame update
    void Awake()
    {
        input = new PlayerControls();
    }

    private void Start()
    {
        input.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        input.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(PrimaryPosition(), (float)context.startTime);
        //Debug.Log(PrimaryPosition());
    }    

    void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(PrimaryPosition(), (float)context.time);
        //Debug.Log(PrimaryPosition());
    }

    public Vector2 PrimaryPosition()
    {
        return ScreenToWorld(input.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

    Vector3 ScreenToWorld(Vector3 postion)
    {
        postion.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(postion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
