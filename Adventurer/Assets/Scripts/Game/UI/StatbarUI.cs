// ######################################################################
// StatbarUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using Project.Game.Combat;

namespace Project.Game.UI
{
	public class StatbarUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private RectTransform m_fillImage;
		[SerializeField] private StatbarDataProvider m_statbarDataProvider;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => m_statbarDataProvider.OnStatValueUpdatedEvent += Health_OnStatValueUpdatedCallback;
		private void OnDisable() => m_statbarDataProvider.OnStatValueUpdatedEvent -= Health_OnStatValueUpdatedCallback;
		#endregion

		#region Internally Used Method(s):
		private void Health_OnStatValueUpdatedCallback(Stat _stat)
		{
			float percentage = (float)_stat.Currentvalue / _stat.Threshold.Max;
			m_fillImage.localScale = new Vector3(percentage, 1f, 1f);
			Debug.Log($"Percentage: {percentage}");
		}
		#endregion
	}
}