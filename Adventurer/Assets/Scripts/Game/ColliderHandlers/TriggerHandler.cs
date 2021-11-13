// ######################################################################
// TriggerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(Collider2D))]
	public class TriggerHandler : MonoBehaviour
	{
		#region  Event/Delegate(s):
		public event Action<Collider2D> OnTriggerEnteredEvent;
		public event Action<Collider2D> OnTriggerExitedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField, TagSelector] private List<string> m_tags;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => GetComponent<Collider2D>().isTrigger = true;
		private void OnTriggerEnter2D(Collider2D _collider)
		{
			if (!m_tags.Contains(_collider.tag)) { return; }

			OnTriggerEnteredEvent?.Invoke(_collider);
			HandleTriggerEnter(_collider);
		}

		private void OnTriggerExit2D(Collider2D _collider)
		{
			if (!m_tags.Contains(_collider.tag)) { return; }
			OnTriggerExitedEvent?.Invoke(_collider);
			HandleTriggerExit(_collider);
		}
		#endregion

		#region Internally Used Method(s):
		protected virtual void HandleTriggerEnter(Collider2D _collider) { }
		protected virtual void HandleTriggerExit(Collider2D _collider) { }
		#endregion
	}
}