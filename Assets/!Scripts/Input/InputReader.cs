using System;
using UnityEngine;

using UnityEngine.InputSystem;

public class InputReader : InputSystem_Actions.IPlayerActions
{
    InputSystem_Actions actions;
    public void Enable()
    {
        actions = new InputSystem_Actions();
        actions.Player.SetCallbacks(this);
        actions.Enable();
    }

    public void Disable()
    {
        actions.Player.RemoveCallbacks(this);
        actions.Disable();
    }

    public Action<Vector2> onMove;
    public void OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }

    public Action<Vector3> onHandPos_R;
    public void OnHandPos_R(InputAction.CallbackContext context)
    {
        onHandPos_R?.Invoke(context.ReadValue<Vector3>());
    }
    public Action<Vector3> onHandPos_L;
    public void OnHandPos_L(InputAction.CallbackContext context)
    {
        onHandPos_L?.Invoke(context.ReadValue<Vector3>());
    }

        public Action<Quaternion> onHandRot_R;
    public void OnHandRot_R(InputAction.CallbackContext context)
    {
        onHandRot_R?.Invoke(context.ReadValue<Quaternion>());
    }
    public Action<Quaternion> onHandRot_L;
    public void OnHandRot_L(InputAction.CallbackContext context)
    {
        onHandRot_L?.Invoke(context.ReadValue<Quaternion>());
    }
}
