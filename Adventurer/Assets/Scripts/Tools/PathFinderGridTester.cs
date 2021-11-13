// ######################################################################
// PathFinderGridTester - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Game
{
	public class PathFinderGridTester : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private int m_width;
		[SerializeField] private int m_height;
		[SerializeField] private float m_cellSize;
		[SerializeField] private Vector3 m_origin;
		[SerializeField] private LayerMask m_colliderLayer;
		[SerializeField] private bool m_debugGridLines;
		[SerializeField] private bool m_debugGizmos;
		#endregion

		#region Internal State Field(s):
		private Grid<bool> m_grid;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			BuildGrid();
		}

		private void OnDrawGizmos() 
		{
			if (!m_debugGizmos || m_grid == null) { return; }

			try
			{
				Vector3 cellSize = new Vector3(m_cellSize, m_cellSize);
				Vector3 halfCellSize = cellSize * 0.5f;
				for (int x = 0; x < m_grid.GridWidth; x++)
				{
					for (int y = 0; y < m_grid.GridHeight; y++)
					{
						bool result = m_grid.GetGridObjectAt(x, y);
						Gizmos.color = (result) ? Color.green : Color.red;

						Vector3 position = m_grid.GetWorldPosition(x, y);
						position += halfCellSize;

						Gizmos.DrawCube(position, cellSize);
					}
				}
			}
			catch(Exception e) { }
		}
		#endregion

		#region Internally Used Method(s):
		public void BuildGrid()
		{
			m_grid = new Grid<bool>(m_width, m_height, m_cellSize, transform.position + m_origin, (Grid<bool> _g, int _x, int _y) => false, m_debugGridLines);
			
			for (int x = 0; x < m_grid.GridWidth; x++)
			{
				for (int y = 0; y < m_grid.GridHeight; y++)
				{	
					Vector3 position = m_grid.GetWorldPosition(x,y);
					float halfCellSize = m_cellSize * 0.5f;
					position += new Vector3(halfCellSize, halfCellSize);


					// bool result = Physics2D.OverlapPoint(position, m_colliderLayer);

					Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.02f, m_colliderLayer);
					bool result = colliders != null && colliders.Length > 0;;

					// bool result = Physics2D.OverlapCircle(position, 0.02f, m_colliderLayer);
					Color debugColor = (result) ? Color.red : Color.green;
					m_grid.DebugCell(x, y, 0.05f, debugColor);

					m_grid.SetGridObjectAt(x, y, !result);
				}
			}
		}
		#endregion
	}
}