// ######################################################################
// ColliderSensorObject - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(Collider2D))]
	public abstract class ColliderSensorObject : MonoBehaviour
	{
		[SerializeField, TagSelector] private List<string> m_tags;
		
		private void OnCollisionEnter2D(Collision2D _collision) 
		{
			if (!m_tags.Contains(_collision.transform.tag)) { return; }
			HandleCollision(_collision);
		}

		protected abstract void HandleCollision(Collision2D _collision);
	}
}