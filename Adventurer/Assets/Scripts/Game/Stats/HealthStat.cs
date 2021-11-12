// ######################################################################
// HealthStat - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Game.Stats
{
    public class HealthStat : StatbarDataProvider
	{
		#region Properties:
		public bool IsAlive => m_stat.Currentvalue > m_stat.Threshold.Min;
		#endregion
	}
}