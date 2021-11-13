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
	public enum TargetType { None, PatrolPoint, Enemy }
	[System.Serializable]
	public class TargetData
	{
		#region Inspector Assigned Field(s):
		[SerializeField, ReadOnly] private TargetType m_targetType;
		[SerializeField, ReadOnly] private List<Vector3> m_movementPathList = new List<Vector3>();
		#endregion

		#region Properties:
		public TargetType TargetType => m_targetType;
		public List<Vector3> MovementPathList => m_movementPathList;
		public Vector3 Destination => (m_movementPathList != null) ? m_movementPathList[m_movementPathList.Count] : Vector3.negativeInfinity;
		#endregion

		#region Constructor(s):
		public TargetData(TargetType _targetType, List<Vector3> _movementPathList)
		{
			m_targetType = _targetType;
			m_movementPathList = _movementPathList;
		}
		#endregion
	}

    public class EnemyTargetManager : MonoBehaviour
	{
		#region Internal State Field(s):
		[SerializeField, ReadOnly] private bool m_hasTarget;
		[SerializeField, ReadOnly] private int m_currentPathIndex = -1;
		// [SerializeField, ReadOnly] private List<Vector3> m_movementPathList = new List<Vector3>();
		[SerializeField, ReadOnly] private TargetData m_targetData = null;
		#endregion

		#region Properties:
		// public bool HasPathData => m_hasTarget = (m_movementPathList != null && m_movementPathList.Count > 0 && m_currentPathIndex < m_movementPathList.Count && m_currentPathIndex >= 0);
		public bool HasPathData => m_hasTarget = (m_targetData != null && m_targetData.TargetType != TargetType.None);
		#endregion

		#region Public API:
		public void SetTarget(Transform _destTrans, TargetType _targetType) => SetTarget(_destTrans.position, _targetType);
		public void SetTarget(Vector3 _destination, TargetType _targetType)
		{
			m_targetData = new TargetData(_targetType, PathFinder.Instance.Grid.FindPath(transform.position, _destination));
			m_currentPathIndex = 1;
		}

		public Vector3 GetCurrentTarget()
		{
			if (!HasPathData)
			{
				ClearPath();
				return Vector3.negativeInfinity;
			}
			
			return m_targetData.MovementPathList[m_currentPathIndex];
		}
		public int GetNextPathIndex()
		{
			m_currentPathIndex++;
	
			if (m_currentPathIndex >= m_targetData.MovementPathList.Count) { ClearPath(); }

			return m_currentPathIndex;
		}
		#endregion

		#region Internally Used Method(s):
		private void ClearPath()
		{
			m_currentPathIndex = -1;
			m_targetData = null;
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator SetPlayerTargetAfterWait()
		{
			yield return new WaitForSeconds(1f);
			SetTarget(GameObject.FindWithTag("Player").transform, TargetType.Enemy);
		}

		private IEnumerator ShowPathCoroutine()
		{
			for (int i = 0; i < m_targetData.MovementPathList.Count - 1; i++)
			{
				Debug.DrawLine(m_targetData.MovementPathList[i], m_targetData.MovementPathList[i + 1], Color.green, 100f);
				yield return new WaitForSeconds(0.1f);
			}
		}
		#endregion
	}
}