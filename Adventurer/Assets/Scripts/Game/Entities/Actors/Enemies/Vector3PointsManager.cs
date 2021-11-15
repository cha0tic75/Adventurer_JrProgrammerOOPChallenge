// ######################################################################
// Vector3PointsManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Entities.Actors.Enemies
{
    public abstract class Vector3PointsManager : MonoBehaviour
	{
		#region Event/Delegate(s):
		public event Action OnEndOfPointsListReachedEvent;
		public event Action OnDestinationReachedEvent;
		#endregion

		#region Constant(s):
		public static Vector3 NO_POINT = Vector2.negativeInfinity;
		public static int NO_INDEX = -1;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] protected List<Vector3> m_vector3Points;
		[SerializeField, ReadOnly] protected int m_index;
		#endregion

		#region Properties:
		public bool HasPoints => m_vector3Points != null && m_vector3Points.Count > 0;
		protected abstract bool RollIndexToZero { get; }
		#endregion

		#region Public API:
		public Vector3 GetCurrentPoint(Vector3 _currentPosition, float _stoppingDistance = 0.2f)
		{
			if (!HasPoints || m_index == NO_INDEX) { return NO_POINT; }

			if (Vector2.Distance(m_vector3Points[m_index], _currentPosition) <= _stoppingDistance)
			{
				OnDestinationReachedEvent?.Invoke();

				int nextIndex = m_index + 1;

                m_index = (RollIndexToZero) ? nextIndex % m_vector3Points.Count : nextIndex;
                
                if(m_index >= m_vector3Points.Count)
                {
                    return HandleEndOfList();
                }
            }

			return m_vector3Points[m_index];
		}
        #endregion

        #region Internally Used Method(s):
        protected abstract void SetVector3PointsList(Vector3 _startPos, Vector3 _endPos);

        private Vector3 HandleEndOfList()
        {
            m_index = NO_INDEX;

            OnEndOfPointsListReachedEvent?.Invoke();
            
			return NO_POINT;
        }
		#endregion
	}
}