// ######################################################################
// PlayerInputHandler - Handles player input by invoking delegates when
//						the playerInput class fires off respected events
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
	[DefaultExecutionOrder(-1)]
    public class PlayerInputHandler : SingletonMonoBehaviour<PlayerInputHandler>
	{
		#region Event/Delegate(s):
		public event Action<Vector2> OnMoveInputActionEvent;
		public event Action<bool> OnSprintInputActionEvent;
		#endregion
		
		#region Public API:
		public void OnMovement(InputValue _inputvalue) => OnMoveInputActionEvent?.Invoke(_inputvalue.Get<Vector2>());
		public void OnSprint(InputValue _inputvalue) => OnSprintInputActionEvent?.Invoke(_inputvalue.Get<float>() > 0.4f);
		#endregion
	}
}