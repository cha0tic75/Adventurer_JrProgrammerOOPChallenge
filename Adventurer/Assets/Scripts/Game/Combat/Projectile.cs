// ######################################################################
// Projectile - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Combat
{
	public class Projectile : ColliderSensorObject, IDamageDealer
	{
        #region Inspector Assigned Field(s):
		[SerializeField] private int m_damage = 10;
        #endregion

        #region Properties:
        public int Damage => m_damage;
        #endregion

		#region Internally Used Method(s):
		protected override void HandleCollision(Collision2D _collision)
        {
            if(_collision.gameObject.TryGetComponent<HealthStat>(out var health))
			{
				health.AlterValue(-m_damage);
				Destroy(gameObject);
			}
        }
		#endregion
	}
}