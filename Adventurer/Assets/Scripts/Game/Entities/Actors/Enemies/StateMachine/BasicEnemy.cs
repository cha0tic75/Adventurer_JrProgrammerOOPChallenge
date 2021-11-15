// ######################################################################
// BasicEnemy - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class BasicEnemy : BaseEnemyStateMachine
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_idleTimeoutTime = 3f;
		[SerializeField] private EnemyPatrolManager m_patrolManager;
		#endregion	

		#region Internally Used Method(s):
		protected override void ConfigureStateMachine()
		{
			var idleState = new EnemyIdleState(m_idleTimeoutTime);
			var patrolState = new EnemyPatrolState(m_targetManager, m_patrolManager, transform);
			var chaseState = new EnemyChaseState(m_targetManager, m_aggroTriger);

			AddTransition(idleState, patrolState, HasIdleTimedOut());
			AddTransition(patrolState, idleState, HasPatrolDestinationReached());

			m_stateMachine.SetState(idleState);

			Func<bool> HasIdleTimedOut() => () => idleState.HasTimedOut;
			Func<bool> HasPatrolDestinationReached() => () => patrolState.HasDestinationReached;
		}
		#endregion
	}
}