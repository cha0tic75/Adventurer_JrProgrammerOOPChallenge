// ######################################################################
// TargetData - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
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
}