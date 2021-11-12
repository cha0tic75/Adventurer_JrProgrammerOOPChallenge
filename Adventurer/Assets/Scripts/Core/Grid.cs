// ######################################################################
// Grid - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Project
{
	[System.Serializable]
	public class Grid<T>
	{
		#region Inspector Assigned Field(s):
		[SerializeField, ReadOnly] private int m_gridWidth;
		[SerializeField, ReadOnly] private int m_gridHeight;
		[SerializeField, ReadOnly] private float m_cellSize;
		[SerializeField, ReadOnly] private Vector2 m_gridOrigin = Vector2.zero;
		#endregion

		#region Internal State Field(s):
		protected T[,] m_grid;
		protected static StringBuilder m_stringBuilder = new StringBuilder();
		#endregion
		
		#region Properties:
		public int GridWidth => m_gridWidth;
		public int GridHeight => m_gridHeight;
		public float GridSize => m_cellSize;
		private bool m_useDebug = false;
		#endregion

		#region Constructor(s):
		public Grid(int _gridWidth, int _gridheight, float _gridSize, bool _useDebug = false)
		{
			m_gridWidth = _gridWidth;
			m_gridHeight = _gridheight;
			m_cellSize = _gridSize;
			m_useDebug = _useDebug;

			InitializeGrid();
		}

		public Grid(int _gridWidth, int _gridheight, float _gridSize, Vector2 m_gridOrigin, bool _useDebug = false) : this(_gridWidth, _gridheight, _gridSize, _useDebug)
		{
			this.m_gridOrigin = m_gridOrigin;
		}
		#endregion
		
		#region Public API:
		public bool IsCoordInGridBounds(int _x, int _y) => _x >= 0 && _x < m_gridWidth && _y >= 0 && _y <= m_gridHeight;
		public bool IsCoordInGridBounds(Vector2Int _coords) => IsCoordInGridBounds(_coords.x, _coords.y);
		// Getter(s):
		public T GetItemAt(int _x, int _y) => (IsCoordInGridBounds(_x, _y)) ? m_grid[_x, _y] : default(T);
		public T GetItemAt(Vector2Int _coords) => GetItemAt(_coords.x, _coords.y);
		public T GetItemAt(Vector2 _worldPosition)
		{
			Vector2Int worldPosition = GetWorldPosition(_worldPosition);

			return GetItemAt(worldPosition.x, worldPosition.y);
		}

		public Vector2 GetWorldPosition(int _x, int _y) => new Vector2(_x, _y) * m_cellSize + m_gridOrigin;

		// Setter(s):
		public void SetItemAt(int _x, int _y, T _item) => m_grid[_x, _y] =  IsCoordInGridBounds(_x, _y) ? _item : default(T);
		public void SetItemAt(Vector2Int _coords, T _item) => SetItemAt(_coords.x, _coords.y, _item);
		public void SetElementAt(Vector2 _worldPosition, T _item)
		{
			Vector2Int worldPosition = GetWorldPosition(_worldPosition);

			SetItemAt(worldPosition.x, worldPosition.y, _item);
		}
		#endregion

		#region Internally Used Method(s):
		private void InitializeGrid()
		{
			m_grid = new T[m_gridWidth, m_gridHeight];

			for (int x = 0; x < m_gridWidth; x++)
			{
				for (int y = 0; y < m_gridWidth; y++)
				{
					m_grid[x, y] = default(T);

					if (m_useDebug)
					{
						Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 50f);
						Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.red, 50f);
					}
				}
			}

			if (m_useDebug)
			{
					Debug.DrawLine(GetWorldPosition(0, m_gridHeight), GetWorldPosition(m_gridWidth, m_gridHeight), Color.red, 50f);
					Debug.DrawLine(GetWorldPosition(m_gridWidth, 0), GetWorldPosition(m_gridWidth, m_gridHeight), Color.red, 50f);
			}
		}

		private Vector2Int GetWorldPosition(Vector2 _worldPosition)
		{
			int x = Mathf.FloorToInt((_worldPosition + m_gridOrigin).x / m_cellSize);
			int y = Mathf.FloorToInt((_worldPosition + m_gridOrigin).y / m_cellSize);

			return new Vector2Int(x, y);
		}
		#endregion
	}
}