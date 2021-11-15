// ######################################################################
// EnemyChaseState - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyChaseState : BaseEnemyState
    {
        #region Internal State Field(s):
        private EnemyTargetManager m_targetManager;
        private EnemyAggroTrigger m_aggroTrigger;
        #endregion

        #region Constructor(s):
        public EnemyChaseState(EnemyTargetManager _targetManager, EnemyAggroTrigger _aggroTrigger) : base()
        {
            m_targetManager = _targetManager;
            m_aggroTrigger = _aggroTrigger;
        }
        #endregion

        #region Public API:
        public override void OnEnter() { }
        public override void OnTick() { }
        public override void OnExit() { }
        #endregion
    }
}