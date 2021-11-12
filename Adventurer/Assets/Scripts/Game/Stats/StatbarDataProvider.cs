// ######################################################################
// StatbarDataProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Game.Stats
{
    public class StatbarDataProvider : MonoBehaviour
	{
		#region Event/Delegate(s):
		public event Action<Stat> OnStatValueUpdatedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] protected MinMaxValue<float> m_threshold;
		[SerializeField] protected float m_startValue;
		[SerializeField, ReadOnly] protected Stat m_stat;
		#endregion

		#region Properties:
		public Stat Stat => m_stat;
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected virtual void Awake() => m_stat = new Stat(m_threshold, m_startValue);
		protected virtual void OnEnable() => m_stat.OnStatValueUpdatedEvent += Stat_OnStatValueUpdatedCallback;
		protected virtual void OnDisable() => m_stat.OnStatValueUpdatedEvent -= Stat_OnStatValueUpdatedCallback;
		#endregion

		#region Public API:
		public void AlterValue(float _damageAmount)
		{
			m_stat.AlterValue(_damageAmount);
			OnStatValueUpdatedEvent?.Invoke(m_stat);
		}
		#endregion

		#region Callback(s):
		protected virtual void Stat_OnStatValueUpdatedCallback(float _alteredValue, Stat _stat)
		{

		}
		#endregion
	}
}