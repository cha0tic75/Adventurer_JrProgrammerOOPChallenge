// ######################################################################
// BaseEnemyStateMachine - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
	public abstract class BaseEnemyStateMachine : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private EnemyAggroTrigger m_aggroTriger;
		[SerializeField] private EnemyTargetManager m_targetManager;
		#endregion

		#region Internal State Field(s):
		private StateMachine m_stateMachine;
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected void Awake()
		{
			m_stateMachine = new StateMachine();
			ConfigureStateMachine();
		}

		protected virtual void OnEnable()
		{

		}

		protected virtual void OnDisable()
		{

		}

		private void Update() => m_stateMachine.Tick();
		#endregion

		#region Internally Used Method(s):
		protected abstract void ConfigureStateMachine();
		#endregion
	}
}