// ######################################################################
// Health - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Game.Combat
{
    [System.Serializable]
	public class Stat
	{
		#region Event/Delegate(s):
		public event Action<int, Stat> OnStatValueUpdatedEvent; // alterValue, currentvalue, stat
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] private MinMaxValue<int> m_threshold;
		[SerializeField, ReadOnly] private int m_currentValue;
		#endregion

        #region Properties:
        public int Currentvalue => m_currentValue;
        public MinMaxValue<int> Threshold => m_threshold;
        #endregion

		#region Constructor(s):
		public Stat() {}
		public Stat(MinMaxValue<int> _threshold, int _start)
		{
			m_threshold = _threshold;
			m_currentValue = _start;
		}
		#endregion

		#region Public API:
		public void AlterValue(int _alterValue)
		{
			m_currentValue = Mathf.Clamp(m_currentValue + _alterValue, m_threshold.Min, m_threshold.Max);
			OnStatValueUpdatedEvent?.Invoke(_alterValue, this);
		}
        public void AlterThreshold(MinMaxValue<int> _threshold) => m_threshold = _threshold;
		#endregion
	}
}