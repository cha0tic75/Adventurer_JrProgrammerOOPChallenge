// ######################################################################
// BaseEnemyState - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyPatrolState : BaseEnemyState
    {
        #region Internal State Field(s):
        private Transform m_transform;
        private EnemyTargetManager m_targetManager;
        private EnemyPatrolManager m_patrolManager;
        #endregion

        #region Properties:
        public bool HasDestinationReached { get; private set; }
        #endregion

        #region Constructor(s):
        public EnemyPatrolState(EnemyTargetManager _targetManager, EnemyPatrolManager _patrolManager, Transform _transform) : base()
        {
            m_targetManager = _targetManager;
            m_patrolManager = _patrolManager;
            m_transform = _transform;
        }
        #endregion

        #region Public API:
        public override void OnEnter()
        {
            HasDestinationReached = false;
            Vector3 destination = m_patrolManager.WaypointHandler.GetCurrentPoint(m_transform.position, m_patrolManager.Stoppingdistance);
            m_targetManager.SetTarget(destination, TargetType.PatrolPoint);
            m_targetManager.OnDestinationReachedEvent += TargetManager_OnDestinationReachedCallback;

            base.OnEnter();
        }
        public override void OnTick() { }
        public override void OnExit()
        {
            m_targetManager.OnDestinationReachedEvent -= TargetManager_OnDestinationReachedCallback;
        }
        #endregion

        #region Internally Used Method(s):
        private void TargetManager_OnDestinationReachedCallback() => HasDestinationReached = true;
        #endregion
    }
}