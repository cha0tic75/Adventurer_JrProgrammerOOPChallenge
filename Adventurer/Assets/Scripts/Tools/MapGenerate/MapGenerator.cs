// ######################################################################
// MapGenerator - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using Project.Game.Entities;
using UnityEditor;
using UnityEngine;

namespace Project.Tools
{
	public class MapGenerator : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private MapCaptureData m_mapCaptureData;
		[SerializeField] private List<Room> m_roomPrefabs;
		#endregion
		
		#region Public API:
		public void DoGenerate()
		{
			if (m_mapCaptureData == null) { return; }
			if (m_roomPrefabs == null || m_roomPrefabs.Count == 0) { return; }

			float cellSize = m_mapCaptureData.CellSize;

			GameObject areaParentTransform = GameObject.Find(m_mapCaptureData.AreaName);
					
			if (areaParentTransform == null)
			{
				areaParentTransform = new GameObject($"{m_mapCaptureData.AreaName}");
				areaParentTransform.transform.SetParent(transform);
			}

			foreach(var roomData in m_mapCaptureData.RoomData)
			{
				Vector2Int coords = roomData.Coordinates;
				Vector2 position = new Vector2(coords.x, coords.y) * cellSize;

				Room roomPrefab = m_roomPrefabs.Find(r => r.RoomShape == roomData.RoomShape);

				if (roomPrefab != null)
				{
					Room prefab = PrefabUtility.InstantiatePrefab(roomPrefab as Room) as Room;
					prefab.transform.position = position;
					prefab.transform.rotation = Quaternion.Euler(0f, 0f, roomData.Rotation);
					prefab.transform.SetParent(areaParentTransform.transform);
					prefab.SetCoords(roomData.Coordinates);
				}
			}
		}
		#endregion
	}
}