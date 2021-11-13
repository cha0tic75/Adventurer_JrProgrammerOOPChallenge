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
		private void Update()
		{
			m_movementInput = Vector2.zero;
			if (m_targetManager == null || !m_targetManager.HasPathData){ return; }

			Vector3 targetPosition = m_targetManager.GetCurrentTarget();

			if (targetPosition == Vector3.negativeInfinity) { return; }

			// Debug.Log(Vector2.Distance(transform.position, targetPosition));

			if (Vector2.Distance(transform.position, targetPosition) < m_stoppingDistance)
			{
				m_targetManager.GetNextPathIndex();
	
				return;
			}

			m_movementInput = (targetPosition - transform.position);
		}
		#endregion
	}
}