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
		#region Constant(s):
		private const float PRESS_THRESHOLD = 0.4f;
		#endregion

		#region Event/Delegate(s):
		public event Action<Vector2> OnMoveInputActionEvent;
		public event Action<bool> OnSprintInputActionEvent;
		public event Action<bool> OnInteractInputActionEvent;
		#endregion
		
		#region Public API:
		public void OnMovement(InputValue _inputValue) => OnMoveInputActionEvent?.Invoke(_inputValue.Get<Vector2>());
		public void OnSprint(InputValue _inputValue) => OnSprintInputActionEvent?.Invoke(IsPressed(_inputValue));
		public void OnInteract(InputValue _inputValue) => OnInteractInputActionEvent?.Invoke(IsPressed(_inputValue));
		#endregion

		#region Internally Used Method(s):
		private bool IsPressed(InputValue _inputValue) => _inputValue.Get<float>() > PRESS_THRESHOLD;
		#endregion
	}
}