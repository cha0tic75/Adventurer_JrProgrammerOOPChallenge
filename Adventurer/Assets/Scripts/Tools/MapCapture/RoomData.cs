// ######################################################################
// RoomData - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Game.Entities;
using UnityEngine;

namespace Project.Tools
{
    [System.Serializable]
	public class RoomData
	{
		public RoomShape RoomShape;
		public Vector2Int Coordinates;
		public float Rotation;
	}
}