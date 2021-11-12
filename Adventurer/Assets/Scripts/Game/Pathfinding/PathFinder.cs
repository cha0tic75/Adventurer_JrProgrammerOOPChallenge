// ######################################################################
// PathFinder - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class PathFinder : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private int m_width;
		[SerializeField] private int m_height;
		[SerializeField] private float m_cellSize;
		// [SerializeField] private Vector3 m_origin;
		#endregion

		#region Internal State Field(s):
		private Grid<int> m_grid;
		#endregion
		
		#region Properties:
		
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			m_grid = new Grid<int>(m_width, m_height, m_cellSize, transform.position, true);
		}

		// private void Update()
		// {
			
		// }
		#endregion
		
		#region Public API:
		
		#endregion

		#region Internally Used Method(s):
		
		#endregion
	}
}