// ######################################################################
// PlayerMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Input;
using UnityEngine;

namespace Project.Entities.Actors
{
    public class PlayerMotor : ActorMotor
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_sprintSpeedModifier;
		[SerializeField, ReadOnly] private bool m_isSprinting = false;
		#endregion

		#region Properties:
		public override float Speed => m_movementSpeed * ((m_isSprinting) ? m_sprintSpeedModifier : 1f);
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected virtual void OnEnable()
		{
			PlayerInputHandler.Instance.OnMoveInputActionEvent += InputHandler_OnMoveInputActionCallback;
			PlayerInputHandler.Instance.OnSprintInputActionEvent += InputHandler_OnSprintInputActionCallback;
		}

		protected virtual void OnDisable()
		{
			PlayerInputHandler.Instance.OnMoveInputActionEvent += InputHandler_OnMoveInputActionCallback;
			PlayerInputHandler.Instance.OnSprintInputActionEvent += InputHandler_OnSprintInputActionCallback;
		}
		#endregion

		#region Callback Method(s):
		private void InputHandler_OnMoveInputActionCallback(Vector2 _movementInput) => m_movementInput = _movementInput;
		private void InputHandler_OnSprintInputActionCallback(bool _sprintState) => m_isSprinting = _sprintState;
		#endregion
	}
}