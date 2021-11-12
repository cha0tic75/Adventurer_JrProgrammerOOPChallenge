// ######################################################################
// MapCapture - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using Project.Game.Entities;
using UnityEditor;
using UnityEngine;

namespace Project.Tools
{
	public class MapCapture : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private string m_areaName;
		[SerializeField] private float m_cellSize;
		#endregion
		
		#region Public API:
		public void DoCapture()
		{
			Room[] areaRooms = GetComponentsInChildren<Room>();
			List<RoomData> areaRoomDatas = new List<RoomData>();
			
			foreach(var room in areaRooms)
			{
				Transform roomTransform = room.transform;
				Vector2 position = roomTransform.position / m_cellSize;

				Vector2Int coordinates = new Vector2Int((int)position.x, (int)position.y);
				// int rotation = (int)(room.transform.rotation.z / 90f);

				// if (rotation == -1) { rotation = 3; }

				RoomShape roomShape = room.RoomShape;

				RoomData newRoomData = new RoomData()
				{
					RoomShape = roomShape, 
					Coordinates = coordinates, 
					Rotation = room.transform.rotation.eulerAngles.z
				};

				areaRoomDatas.Add(newRoomData);
			}

			MapCaptureData mapCaptureData = ScriptableObject.CreateInstance<MapCaptureData>();
			mapCaptureData.Initialize(m_areaName, m_cellSize, areaRoomDatas);

			AssetDatabase.CreateAsset(mapCaptureData, $"Assets/MapData/{m_areaName}.asset");
			AssetDatabase.SaveAssets();
		}
		#endregion
	}
}