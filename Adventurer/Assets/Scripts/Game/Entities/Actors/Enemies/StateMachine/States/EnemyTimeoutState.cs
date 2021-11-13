// ######################################################################
// EnemyTimeoutState - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public abstract class EnemyTimeoutState : BaseEnemyState
    {
        #region Internal State Field(s):
        protected float m_timeoutTime;
        protected float m_timer;
        #endregion

        #region Properties:
        public bool HasTimedOut => m_timeoutTime > 0 && m_timer >= m_timeoutTime;
        #endregion

        #region Constructor(s):
        public EnemyTimeoutState(float _timeoutTime = -1) : base()
        {
            m_timeoutTime = _timeoutTime;
        }
        #endregion

        #region Public API:
        public override void OnEnter()
        { 
            m_timer = 0;
            base.OnEnter();
        }

        public override void OnTick()
        {
            if (m_timeoutTime > 0) { m_timer += Time.deltaTime; }
            base.OnTick();
        }
        #endregion
    }
}