// ######################################################################
// ActorCollisionBlocker - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Entities.Actors
{
	[RequireComponent(typeof(Collider2D))]
	public class ActorCollisionBlocker : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Collider2D m_characterCollider;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => Physics2D.IgnoreCollision(m_characterCollider, GetComponent<Collider2D>(), true);
		#endregion
	}
}