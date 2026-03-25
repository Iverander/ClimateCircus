using System;
using UnityEngine;

using UnityEngine.InputSystem;

public class InputReader : InputSystem_Actions.IPlayerActions, InputSystem_Actions.ILeftHandActions, InputSystem_Actions.IRightHandActions
{
    InputSystem_Actions actions;
    public void Enable()
    {
        actions = new InputSystem_Actions();
        actions.Player.SetCallbacks(this);
        actions.LeftHand.SetCallbacks(this);
        actions.RightHand.SetCallbacks(this);
        actions.Enable();
    }

    public void Disable()
    {
        actions.Player.RemoveCallbacks(this);
        actions.LeftHand.SetCallbacks(this);
        actions.RightHand.SetCallbacks(this);
        actions.Disable();
    }

    public Action<Vector2> onMove;
    void InputSystem_Actions.IPlayerActions.OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }

    #region RightController
    
    public Action<Vector3> onHandPos_R;
    void InputSystem_Actions.IRightHandActions.OnHandPos(InputAction.CallbackContext context)
    {
        onHandPos_R?.Invoke(context.ReadValue<Vector3>());
    }

    public Action<Quaternion> onHandRot_R;
    void InputSystem_Actions.IRightHandActions.OnHandRot(InputAction.CallbackContext context)
    {
        onHandRot_R?.Invoke(context.ReadValue<Quaternion>());
    }

    public Action Grab_R;
    public Action UnGrab_R;
    void InputSystem_Actions.IRightHandActions.OnGrab(InputAction.CallbackContext context)
    {
        if(context.started)
            Grab_R?.Invoke();
        else if (context.canceled)
            UnGrab_R?.Invoke();
    }

    #endregion
    
    
    #region LeftController
    public Action<Vector3> onHandPos_L;
    void InputSystem_Actions.ILeftHandActions.OnHandPos(InputAction.CallbackContext context)
    {
        onHandPos_L?.Invoke(context.ReadValue<Vector3>());
    }
    public Action<Quaternion> onHandRot_L;
    void InputSystem_Actions.ILeftHandActions.OnHandRot(InputAction.CallbackContext context)
    {
        onHandRot_L?.Invoke(context.ReadValue<Quaternion>());
    }
    
    public Action Grab_L;
    public Action UnGrab_L;
    void InputSystem_Actions.ILeftHandActions.OnGrab(InputAction.CallbackContext context)
    {
        if(context.started)
            Grab_L?.Invoke();
        else if (context.canceled)
            UnGrab_L?.Invoke();
    }
    
    public void OnTracking(InputAction.CallbackContext context)
    {
       Debug.Log(context.ReadValue<int>()); 
    }
    #endregion
}
