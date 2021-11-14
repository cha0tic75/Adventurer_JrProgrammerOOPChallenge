// ######################################################################
// EnemyPatrolManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyPatrolManager : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private WaypointHandler m_waypointHandler;
		#endregion

		#region Properties:
		public WaypointHandler WaypointHandler => m_waypointHandler;
		#endregion
	}
}