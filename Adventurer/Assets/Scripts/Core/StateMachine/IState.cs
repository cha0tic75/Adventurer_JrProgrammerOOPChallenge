// ######################################################################
// IState - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project
{
    public interface IState
	{
		void OnEnter();
		void OnTick();
		void OnExit();
	}
}