// ######################################################################
// StaminaHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using Project.Input;

namespace Project.Game.Stats
{
    public class StaminaHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_regenAmount = 4f;
		[SerializeField] private float m_sprintCost = 7f;
		[SerializeField] private StaminaStat m_staminaStat;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInput;
        private bool m_sprintInput = false;
		#endregion

		#region Properties:
		public bool IsSprinting => m_sprintInput && m_staminaStat.Stat.Currentvalue > m_sprintCost;
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
		private void Update()
		{
			// This should regenerate stamina if player isn't moving
			if (m_movementInput == Vector2.zero) { AdjustStamina(m_regenAmount); }
			else if(IsSprinting) { AdjustStamina(-m_sprintCost); }
		}
		#endregion

		#region Internally Used Method(s):
		private void AdjustStamina(float _adjustval)
		{
			m_staminaStat.AlterValue(_adjustval * Time.deltaTime);
		}
		#endregion

		#region Callback Method(s):
		private void InputHandler_OnMoveInputActionCallback(Vector2 _movementInput) => m_movementInput = _movementInput;
		private void InputHandler_OnSprintInputActionCallback(bool _sprintState) => m_sprintInput = _sprintState;
		#endregion
	}
}