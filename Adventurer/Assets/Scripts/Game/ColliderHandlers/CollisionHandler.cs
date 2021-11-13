// ######################################################################
// CollisionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(Collider2D))]
	public abstract class CollisionHandler : MonoBehaviour
	{
		#region Event/Delegate(s):
		public event Action<Collision2D> OnCollisionEnteredEvent;
		public event Action<Collision2D> OnCollisionExitedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField, TagSelector] private List<string> m_tags;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnCollisionEnter2D(Collision2D _collision) 
		{
			if (!m_tags.Contains(_collision.transform.tag)) { return; }

			OnCollisionEnteredEvent?.Invoke(_collision);
			HandleCollisionEnter(_collision);
		}

		private void OnCollisionExit2D(Collision2D _collision) 
		{
			if (!m_tags.Contains(_collision.transform.tag)) { return; }

			OnCollisionExitedEvent?.Invoke(_collision);
			HandleCollisionExit(_collision);
		}
		#endregion

		#region Internal State Field(s):
		protected virtual void HandleCollisionEnter(Collision2D _collision) { }
		protected virtual void HandleCollisionExit(Collision2D _collision) { }
		#endregion
	}
}