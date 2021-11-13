// ######################################################################
// AggroTrigger - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
	[RequireComponent(typeof(Collider2D))]
	public class AggroTrigger : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField, TagSelector] private List<string> m_tags;
		[SerializeField] private float m_chaseTime = 1.5f;
		[SerializeField] private EnemyTargetManager m_targetManager;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_stopChaseCoroutine = null;
		private WaitForSeconds m_chaseWFS = null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_chaseWFS = new WaitForSeconds(m_chaseTime);
		private void Start() => GetComponent<Collider2D>().isTrigger = true;
		private void OnTriggerEnter2D(Collider2D _collider)
		{
			if (!m_tags.Contains(_collider.tag)) { return; }

			if (m_stopChaseCoroutine != null)
			{
				StopCoroutine(m_stopChaseCoroutine);
			}

			m_targetManager?.SetTarget(_collider.transform);
		}

		private void OnTriggerExit2D(Collider2D _collider)
		{
			if (!m_tags.Contains(_collider.tag)) { return; }

			if (m_stopChaseCoroutine != null)
			{
				StopCoroutine(m_stopChaseCoroutine);
			}

			m_stopChaseCoroutine = StartCoroutine(StopChaseCoroutine());
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator StopChaseCoroutine()
		{
			yield return m_chaseWFS;
			m_targetManager?.SetTarget(null);
		}
		#endregion
	}
}