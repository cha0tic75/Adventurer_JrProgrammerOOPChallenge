// ######################################################################
// EnemyTargetManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using Project.Game.AIPathFinding;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyTargetManager : Vector3PointsManager
	{
		#region Inspector Visible Field(s):
		[SerializeField, ReadOnly] private TargetType m_targetType;
		[SerializeField, ReadOnly] private Vector3 m_destination;
		#endregion

		#region Properties:
		protected override bool RollIndexToZero => false;
		#endregion

		#region Public API:
		public void SetTarget(Transform _transform, TargetType _targetType) => SetTarget(_transform.position, _targetType);

		public void SetTarget(Vector3 _destination, TargetType _targetType)
		{
			m_destination = _destination;
			m_targetType = _targetType;
			SetVector3PointsList(transform.position, _destination);
		}
		#endregion

		#region Internally Used Method(s):
		protected override void SetVector3PointsList(Vector3 _startPos, Vector3 _endPos)
		{
			m_vector3Points = new List<Vector3>(PathFinder.Instance.Grid.FindPath(_startPos, _endPos));
			m_index = (Vector2.Distance(_startPos, m_vector3Points[0]) < 0.2f) ? 1 : 0;
		}
		#endregion
	}

    // public class EnemyTargetManagerOLD : MonoBehaviour
	// {
	// 	#region Internal State Field(s):
	// 	[SerializeField, ReadOnly] private bool m_hasTarget;
	// 	[SerializeField, ReadOnly] private int m_currentPathIndex = -1;
	// 	// [SerializeField, ReadOnly] private List<Vector3> m_movementPathList = new List<Vector3>();
	// 	[SerializeField, ReadOnly] private TargetData m_targetData = null;
	// 	#endregion

	// 	#region Properties:
	// 	// public bool HasPathData => m_hasTarget = (m_movementPathList != null && m_movementPathList.Count > 0 && m_currentPathIndex < m_movementPathList.Count && m_currentPathIndex >= 0);
	// 	public bool HasPathData => m_hasTarget = (m_targetData != null && m_targetData.TargetType != TargetType.None);
	// 	#endregion

	// 	#region Public API:
	// 	public void SetTarget(Transform _destTrans, TargetType _targetType) => SetTarget(_destTrans.position, _targetType);
	// 	public void SetTarget(Vector3 _destination, TargetType _targetType)
	// 	{
	// 		m_targetData = new TargetData(_targetType, PathFinder.Instance.Grid.FindPath(transform.position, _destination));
	// 		m_currentPathIndex = 1;
	// 	}

	// 	public Vector3 GetCurrentTarget()
	// 	{
	// 		if (!HasPathData)
	// 		{
	// 			ClearPath();
	// 			return Vector3.negativeInfinity;
	// 		}
			
	// 		return m_targetData.MovementPathList[m_currentPathIndex];
	// 	}
	// 	public int GetNextPathIndex()
	// 	{
	// 		m_currentPathIndex++;
	
	// 		if (m_currentPathIndex >= m_targetData.MovementPathList.Count) { ClearPath(); }

	// 		return m_currentPathIndex;
	// 	}
	// 	#endregion

	// 	#region Internally Used Method(s):
	// 	private void ClearPath()
	// 	{
	// 		m_currentPathIndex = -1;
	// 		m_targetData = null;
	// 	}
	// 	#endregion

	// 	#region Coroutine(s):
	// 	private IEnumerator SetPlayerTargetAfterWait()
	// 	{
	// 		yield return new WaitForSeconds(1f);
	// 		SetTarget(GameObject.FindWithTag("Player").transform, TargetType.Enemy);
	// 	}

	// 	private IEnumerator ShowPathCoroutine()
	// 	{
	// 		for (int i = 0; i < m_targetData.MovementPathList.Count - 1; i++)
	// 		{
	// 			Debug.DrawLine(m_targetData.MovementPathList[i], m_targetData.MovementPathList[i + 1], Color.green, 100f);
	// 			yield return new WaitForSeconds(0.1f);
	// 		}
	// 	}
	// 	#endregion
	// }
}