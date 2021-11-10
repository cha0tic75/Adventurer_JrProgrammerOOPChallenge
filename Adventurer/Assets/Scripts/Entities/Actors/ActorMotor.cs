// ######################################################################
// ActorMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Entities.Actors
{
    [RequireComponent(typeof(Rigidbody2D))]
	public abstract class ActorMotor : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] protected float m_movementSpeed;
		#endregion

		#region Internal State Field(s):
		private Rigidbody2D m_rigidbody2D;
		protected Vector2 m_movementInput;
		#endregion
		
		#region Properties:
		public virtual float Speed => m_movementSpeed;
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected virtual void Awake() => m_rigidbody2D = GetComponent<Rigidbody2D>();

		private void FixedUpdate()
		{
            m_rigidbody2D.velocity = m_movementInput * Speed * Time.fixedDeltaTime;
		}
		#endregion
	}
}