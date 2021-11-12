// ######################################################################
// MapCaptureData - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Tools
{
    public class MapCaptureData : ScriptableObject
	{
		#region Inspector Assigned Field(s):
		[SerializeField, ReadOnly] private string m_areaName;
		[SerializeField, ReadOnly] private float m_cellSize;
		[SerializeField, ReadOnly] private List<RoomData> m_roomData;
		#endregion

		#region Properties:
		public string AreaName => m_areaName;
		public float CellSize => m_cellSize;
		public List<RoomData> RoomData => m_roomData;
		#endregion
		
		#region Public API:
		public void Initialize(string _areaName, float _cellSize, List<RoomData> _roomData)
		{
			m_areaName = _areaName;
			m_cellSize = _cellSize;
			m_roomData = new List<RoomData>(_roomData); 
		}
		#endregion
	}
}