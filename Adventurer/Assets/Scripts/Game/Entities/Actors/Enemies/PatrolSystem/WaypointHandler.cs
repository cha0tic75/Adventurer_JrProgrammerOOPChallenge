// ######################################################################
// WaypointHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class WaypointHandler : Vector3PointsManager
    {
		#region Properties:
        protected override bool RollIndexToZero => true;
		#endregion

		#region MonoBehaiour Callback Method(s):
		private void Awake() => transform.SetParent(null);
		private void Start()
		{
			foreach(var trans in GetComponentsInChildren<Transform>())
			{
				if (trans == transform) { continue; }
				m_vector3Points.Add(trans.position);
			}

			m_index = 0;
		}
		#endregion

        protected override void SetVector3PointsList(Vector3 _startPos, Vector3 _endPos)
        {

        }
    }

    // public class WaypointHandlerOld : MonoBehaviour
	// {
	// 	#region Inspector Assigned Field(s):
	// 	[SerializeField] private List<Transform> m_wayPoints;
	// 	#endregion

	// 	#region Internal State Field(s):
	// 	private int m_wayPointIndex = 1;
	// 	#endregion

	// 	#region Properties:
	// 	public bool HasWaypoints => m_wayPoints != null && m_wayPoints.Count > 0;
	// 	#endregion
	
	// 	#region MonoBehaiour Callback Method(s):
	// 	private void Start()
	// 	{
	// 		if (m_wayPoints == null || m_wayPoints.Count == 0)
	// 		{
	// 			GetComponentsInChildren<Transform>(result: m_wayPoints, includeInactive: false);
	// 			m_wayPoints.Remove(transform);
	// 		}

	// 		transform.SetParent(null);
	// 	}
	// 	#endregion

	// 	#region Public API:
	// 	public Vector3 GetCurrentWayPointPosition() => m_wayPoints[m_wayPointIndex].position;
	// 	public Vector3 GetDestination(Vector3 _currentPosition, float _stoppingDistance)
	// 	{
	// 		if (!HasWaypoints || _currentPosition == Vector3.negativeInfinity) { return Vector3.negativeInfinity; }

	// 		if (Vector3.Distance(_currentPosition, m_wayPoints[m_wayPointIndex].position) <= _stoppingDistance)
	// 		{
	// 			m_wayPointIndex = (m_wayPointIndex + 1) % m_wayPoints.Count;
	// 		}

	// 		return m_wayPoints[m_wayPointIndex].position;
	// 	}
	// 	#endregion
	// }
}