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

    public Action<Vector3> onRHandPos;
    public void OnRightHand_Pos(InputAction.CallbackContext context)
    {
        
    }
        public Action<Vector3> onLHandPos;
    public void OnLeftHand_Pos(InputAction.CallbackContext context)
    {
        
    }
}
