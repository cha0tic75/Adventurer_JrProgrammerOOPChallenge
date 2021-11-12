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
		[SerializeField] private Vector3 m_origin;
		[SerializeField] private LayerMask m_colliderLayer;
		[SerializeField] private bool m_debug;
		#endregion

		#region Internal State Field(s):
		private Grid<bool> m_grid;
		#endregion
		
		#region Properties:
		
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			BuildGrid();
		}

		// private void Update()
		// {

		// }

		private void OnDrawGizmos() 
		{
			if (!m_debug || m_grid == null) { return; }

			Gizmos.color = Color.red;
			for (int x = 0; x < m_grid.GridWidth; x++)
			{
				for (int y = 0; y < m_grid.GridHeight; y++)
				{
					bool result = m_grid.GetItemAt(x, y);
					if (result) { continue; }
					Vector3 position = new Vector3(x, y) * m_cellSize;
					Gizmos.DrawCube(position, Vector3.one);
				}
			}

		}
		#endregion
		
		#region Public API:
		
		#endregion

		#region Internally Used Method(s):
		private void BuildGrid()
		{
			m_grid = new Grid<bool>(m_width, m_height, m_cellSize, transform.position + m_origin, true);
			for (int x = 0; x < m_grid.GridWidth; x++)
			{
				for (int y = 0; y < m_grid.GridHeight; y++)
				{
					Vector3 position = new Vector3(x, y) * m_cellSize;
					// Do an overlapse sphere in middle of cell and see if it hits collider
					bool results = Physics2D.OverlapCircle(position, m_cellSize * 0.1f, m_colliderLayer);
					m_grid.SetItemAt(x, y, !results);
				}
			}
		}
		#endregion
	}
}