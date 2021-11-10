// ######################################################################
// ScreenFader - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections;
using UnityEngine;

namespace Project
{
	[RequireComponent(typeof(CanvasGroup))]
	public class ScreenFader : MonoBehaviour
	{
		#region Event/Delegate(s):
		public event Action OnFadeCoroutineCompletedEvent;
		public event Action OnFadeOutFadeInCoroutineCompletedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] private float m_defaultFadeDuration;
		#endregion

		#region Internal State Field(s):
		private CanvasGroup m_canvasGroup;
		private Coroutine m_fadeCoroutine = null;
		private Coroutine m_doFadeOutFadeIn = null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_canvasGroup = GetComponent<CanvasGroup>();
		#endregion

		#region Public API:
		public void DoFadeOutFadeIn(float _delayTime, float _fadeOutDuration = 0f, float FadeInDuration = 0f)
		{
			if (m_doFadeOutFadeIn != null)
			{
				StopCoroutine(m_doFadeOutFadeIn);
			}

			m_doFadeOutFadeIn = 
				StartCoroutine(DoFadeOutFadeInCoroutine(GetFadeDuration(_fadeOutDuration), GetFadeDuration(FadeInDuration), _delayTime));
		}
	
		public void DoFadeIn(float _fadeDuration = 0f) => DoFade(0f, GetFadeDuration(_fadeDuration));
		public void DoFadeOut(float _fadeDuration = 0f) => DoFade(1f, GetFadeDuration(_fadeDuration));
		#endregion

		#region Internally Used Method(s):
		private float GetFadeDuration(float _fadeDuration) => (_fadeDuration > 0) ? _fadeDuration : m_defaultFadeDuration;
		private void DoFade(float _targetValue, float _fadeDuration)
		{
			if (m_fadeCoroutine != null)
			{
				StopCoroutine(m_fadeCoroutine);
			}

			m_fadeCoroutine = StartCoroutine(DoFadeCoroutine(_targetValue, _fadeDuration));
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator DoFadeOutFadeInCoroutine(float _fadeOutDuration,float _fadeInDuration, float _delayTime)
		{
			yield return m_fadeCoroutine = StartCoroutine(DoFadeCoroutine(1f, _fadeOutDuration));
			yield return new WaitForSeconds(_delayTime);
			yield return m_fadeCoroutine = StartCoroutine(DoFadeCoroutine(0f, _fadeInDuration));
			m_doFadeOutFadeIn = null;
			OnFadeOutFadeInCoroutineCompletedEvent?.Invoke();
		}

		private IEnumerator DoFadeCoroutine(float _targetValue, float _duration)
		{
			float time = 0;
			float startValue = m_canvasGroup.alpha;

			while (time < _duration)
			{
				m_canvasGroup.alpha = Mathf.Lerp(startValue, _targetValue, time / _duration);
				time += Time.deltaTime;
				yield return null;
			}

			m_canvasGroup.alpha = _targetValue;
			m_fadeCoroutine = null;
			OnFadeCoroutineCompletedEvent?.Invoke();
		}
		#endregion
	}
}