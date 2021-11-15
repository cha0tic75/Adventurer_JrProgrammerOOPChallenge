// ######################################################################
// EnemyMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{

    [RequireComponent(typeof(EnemyTargetManager))]
    public class EnemyMotor : ActorMotor
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_stoppingDistance = 0.05f;
		#endregion

		#region Internal State Field(s):
		private EnemyTargetManager m_targetManager;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => m_targetManager = GetComponent<EnemyTargetManager>();
		#endregion

		#region Internally Used Method(s):
		protected override void FixedUpdate()
		{
			// m_movementInput = Vector2.zero;

			if (m_targetManager == null || !m_targetManager.HasPoints){ return; }

			Vector3 targetPosition = m_targetManager.GetCurrentPoint(transform.position, m_stoppingDistance);

			if (targetPosition == EnemyTargetManager.NO_POINT)
			{
				Debug.Log("targetPos has no point!"); 
				return; 
			}

			Vector2 direction = (targetPosition - transform.position);
			m_movementInput = (!direction.IsNaN()) ? direction : Vector2.zero;

			base.FixedUpdate();
		}
		#endregion
	}
}