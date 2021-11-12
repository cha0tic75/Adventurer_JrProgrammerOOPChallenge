// ######################################################################
// Health - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Game.Stats
{
    [System.Serializable]
	public class Stat
	{
		#region Event/Delegate(s):
		public event Action<float, Stat> OnStatValueUpdatedEvent; // alterValue, currentvalue, stat
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] private MinMaxValue<float> m_threshold;
		[SerializeField, ReadOnly] private float m_currentValue;
		#endregion

        #region Properties:
        public float Currentvalue => m_currentValue;
        public MinMaxValue<float> Threshold => m_threshold;
        #endregion

		#region Constructor(s):
		public Stat() {}
		public Stat(MinMaxValue<float> _threshold, float _start)
		{
			m_threshold = _threshold;
			m_currentValue = _start;
		}
		#endregion

		#region Public API:
		public void AlterValue(float _alterValue)
		{
			m_currentValue = Mathf.Clamp(m_currentValue + _alterValue, m_threshold.Min, m_threshold.Max);
			OnStatValueUpdatedEvent?.Invoke(_alterValue, this);
		}
        public void AlterThreshold(MinMaxValue<float> _threshold) => m_threshold = _threshold;
		#endregion
	}
}