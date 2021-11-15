// ######################################################################
// EnemyAggroTrigger - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyAggroTrigger : TriggerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private EnemyTargetManager m_enemyTargetManager;
        #endregion

        #region Internally Used Method(s):
        protected override void HandleTriggerEnter(Collider2D _collider)
        {
            m_enemyTargetManager?.SetTarget(_collider.transform, TargetType.Enemy);
        }
        #endregion
    }
}