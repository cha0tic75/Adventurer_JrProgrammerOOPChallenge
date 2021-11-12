// ######################################################################
// StatbarUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using UnityEngine.UI;
using Project.Game.Stats;
using TMPro;

namespace Project.Game.UI
{
	public class StatbarUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private string m_displayName;
		[SerializeField] private Image m_fillImage;
		[SerializeField] private Color m_fillColor = new Color(1f, 1f, 1f, 1f);
		[SerializeField] private TextMeshProUGUI m_statNameTMP;
		[SerializeField] private Color m_textColor = new Color(1f, 1f, 1f, 1f);
		[SerializeField] private StatbarDataProvider m_statbarDataProvider;
		#endregion

		#region Internal State Field(s):
		private RectTransform m_fillRectTransform;
		#endregion

		#region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
		private void OnValidate()
		{
			if (m_statNameTMP != null)
			{ 
				m_statNameTMP.SetText(m_displayName); 
				m_statNameTMP.color = m_textColor;
			}
			if (m_fillImage != null) { m_fillImage.color = m_fillColor; }
		}
#endif
		private void Awake() => m_fillRectTransform = m_fillImage.GetComponent<RectTransform>();
		private void OnEnable() => m_statbarDataProvider.OnStatValueUpdatedEvent += Health_OnStatValueUpdatedCallback;
		private void OnDisable() => m_statbarDataProvider.OnStatValueUpdatedEvent -= Health_OnStatValueUpdatedCallback;
		#endregion

		#region Internally Used Method(s):
		private void Health_OnStatValueUpdatedCallback(Stat _stat)
		{
			float percentage = Mathf.Clamp01((float)_stat.Currentvalue / _stat.Threshold.Max);
			m_fillRectTransform.localScale = new Vector3(percentage, 1f, 1f);
			Debug.Log($"Percentage: {percentage}");
		}
		#endregion
	}
}