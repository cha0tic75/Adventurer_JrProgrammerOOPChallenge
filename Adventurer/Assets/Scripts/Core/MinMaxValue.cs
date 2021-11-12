// ######################################################################
// MinMaxValue - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [System.Serializable]
	public class MinMaxValue<T>
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private T m_min;
		[SerializeField] private T m_max;
		#endregion

		#region Properties:
		public T Min => m_min;
		public T Max => m_max;
		#endregion

		#region Constructor(s):
		public MinMaxValue() { }
		public MinMaxValue(T _min, T _max)
		{
			m_min = _min;
			m_max = _max;
		}
		#endregion
	}
}