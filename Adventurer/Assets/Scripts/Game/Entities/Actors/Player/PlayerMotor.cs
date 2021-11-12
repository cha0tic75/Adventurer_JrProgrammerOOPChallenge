// ######################################################################
// PlayerMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Game.Stats;
using Project.Input;
using UnityEngine;

namespace Project.Game.Entities.Actors
{
    public class PlayerMotor : ActorMotor
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_sprintSpeedModifier;
		[SerializeField] private StaminaHandler m_staminaHandler;
		#endregion

		#region Properties:
		public override float Speed => m_movementSpeed * ((m_staminaHandler.IsSprinting) ? m_sprintSpeedModifier : 1f);
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected virtual void OnEnable()
		{
			PlayerInputHandler.Instance.OnMoveInputActionEvent += InputHandler_OnMoveInputActionCallback;
		}

		protected virtual void OnDisable()
		{
			PlayerInputHandler.Instance.OnMoveInputActionEvent += InputHandler_OnMoveInputActionCallback;
		}
		#endregion

		#region Callback Method(s):
		private void InputHandler_OnMoveInputActionCallback(Vector2 _movementInput) => m_movementInput = _movementInput;
		#endregion
	}
}