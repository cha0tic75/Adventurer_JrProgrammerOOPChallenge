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
        public EnemyTargetManager m_enemyTargetManager;
        protected override void HandleTriggerEnter(Collider2D _collider)
        {
            m_enemyTargetManager.SetTarget(_collider.transform, TargetType.Enemy);
        }
    }
}