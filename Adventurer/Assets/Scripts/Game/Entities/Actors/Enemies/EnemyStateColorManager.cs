// ######################################################################
// EnemyStateColorManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class EnemyStateColorManager : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Color m_idleColor;
		[SerializeField] private Color m_aggroColor;
		[SerializeField] private float m_smoothTime = 0.2f;
		[Header("References")]
		[SerializeField] private SpriteRenderer m_spriteRenderer;
		#endregion

		#region Internal State Field(s):
		
		#endregion
		
		#region Properties:
		
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			m_spriteRenderer.color = m_idleColor;
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator LerpColoCoroutiner(Color _targetColor, float _duration)
		{
			float time = 0;
			Color startValue = m_spriteRenderer.color;

			while (time < _duration)
			{
				m_spriteRenderer.color = Color.Lerp(startValue, _targetColor, time / _duration);
				time += Time.deltaTime;
				yield return null;
			}
	
			m_spriteRenderer.color = _targetColor;
		}
		#endregion
	}
}