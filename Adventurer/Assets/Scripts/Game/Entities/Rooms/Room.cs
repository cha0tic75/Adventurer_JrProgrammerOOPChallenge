// ######################################################################
// Room - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Entities
{
    public enum RoomShape
	{
		None = 0, 
		Room_O = 100,
		Room_U = 200,
		Room_L = 300,
		Room_I = 400, 
		Room_T = 500, 
		Room_X = 600, 
	}

	public class Room : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private RoomShape m_roomShape;
		[SerializeField] private Vector2Int m_coordinates;
		#endregion

		#region Internal State Field(s):
		
		#endregion
		
		#region Properties:
		public RoomShape RoomShape => m_roomShape;
		#endregion

		// #region MonoBehaviour Callback Method(s):
		// private void Start()
		// {
			
		// }

		// private void Update()
		// {
			
		// }
		// #endregion
		
		#region Public API:
		public void SetCoords(Vector2Int _coords) => m_coordinates = _coords;
		#endregion

		#region Internally Used Method(s):
		
		#endregion
	}
}