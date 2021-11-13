// ######################################################################
// EnemyIdleState - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyIdleState : EnemyTimeoutState
    {
        #region Constructor(s):
        public EnemyIdleState(float _timeoutTime) : base(_timeoutTime) { }
        #endregion

        #region Public API:
        public override void OnEnter() => base.OnEnter();
        public override void OnTick() => base.OnTick();
        // public override void OnExit() => base.OnExit();
        #endregion
    }
}