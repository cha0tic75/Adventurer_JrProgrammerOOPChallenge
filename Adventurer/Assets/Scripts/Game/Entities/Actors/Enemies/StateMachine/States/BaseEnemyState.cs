// ######################################################################
// BaseEnemyState - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################


namespace Project.Game.Entities.Actors.Enemies
{
    public abstract class BaseEnemyState : IState
    {
        #region Internal State Field(s):

        #endregion

        #region Constructor(s):
		public BaseEnemyState() {}
        #endregion

        #region Public API:
        public virtual void OnEnter() {}
        public virtual void OnTick() { }
        public virtual void OnExit() { }

        #endregion
    }
}