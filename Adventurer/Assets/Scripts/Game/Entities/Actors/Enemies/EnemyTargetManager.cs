// ######################################################################
// EnemyTargetManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using Project.Game.AIPathFinding;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public class EnemyTargetManager : MonoBehaviour
	{
		#region Internal State Field(s):
		[SerializeField, ReadOnly] private bool m_hasTarget;
		[SerializeField, ReadOnly] private int m_currentPathIndex = -1;
		[SerializeField, ReadOnly] private List<Vector3> m_movementPathList = new List<Vector3>();
		#endregion

		#region Properties:
		public bool HasPathData => m_hasTarget = (m_movementPathList != null && m_movementPathList.Count > 0 && m_currentPathIndex < m_movementPathList.Count && m_currentPathIndex >= 0);
		#endregion

		// Test Code: Start
		// private void Start() => StartCoroutine(SetPlayerTargetAfterWait());
		// Test Code: End

		#region Public API:
		public void SetTarget(Transform _targetTrans) => SetTarget(_targetTrans.position);
		public void SetTarget(Vector3 _targetPos)
		{
			m_movementPathList = PathFinder.Instance.Grid.FindPath(transform.position, _targetPos);
			m_currentPathIndex = 1;
		}

		public Vector3 GetCurrentTarget()
		{
			if (!HasPathData)
			{
				ClearPath();
				return Vector3.negativeInfinity;
			}
			
			return m_movementPathList[m_currentPathIndex];
		}
		public int GetNextPathIndex()
		{
			m_currentPathIndex++;
	
			if (!HasPathData) { ClearPath(); }

			return m_currentPathIndex;
		}
		#endregion

		#region Internally Used Method(s):
		private void ClearPath()
		{
			m_currentPathIndex = -1;
			m_movementPathList.Clear();
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator SetPlayerTargetAfterWait()
		{
			yield return new WaitForSeconds(1f);
			SetTarget(GameObject.FindWithTag("Player").transform);
		}
		#endregion
	}
}