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
		[SerializeField, ReadOnly] private Vector3 m_gridOrigin = Vector2.zero;
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
		public Grid(int _gridWidth, int _gridheight, float _gridSize, Vector3 _gridOrigin, bool _useDebug = false)
		{
			m_gridWidth = _gridWidth;
			m_gridHeight = _gridheight;
			m_cellSize = _gridSize;
			m_gridOrigin = _gridOrigin;
			m_useDebug = _useDebug;

			InitializeGrid();

			if (m_useDebug)
			{
				DrawDebugLines();
			}
		}
		#endregion
		
		#region Public API:
		public bool IsCoordInGridBounds(int _x, int _y) => _x >= 0 && _x < m_gridWidth && _y >= 0 && _y <= m_gridHeight;
		public bool IsCoordInGridBounds(Vector2Int _coords) => IsCoordInGridBounds(_coords.x, _coords.y);
		// Getter(s):
		public T GetItemAt(int _x, int _y) => (IsCoordInGridBounds(_x, _y)) ? m_grid[_x, _y] : default(T);
		public T GetItemAt(Vector2Int _coords) => GetItemAt(_coords.x, _coords.y);
		public T GetItemAt(Vector3 _worldPosition)
		{
			Vector2Int worldPosition = GetXY(_worldPosition);

			return GetItemAt(worldPosition.x, worldPosition.y);
		}

		// Setter(s):
		public void SetItemAt(int _x, int _y, T _item) => m_grid[_x, _y] =  IsCoordInGridBounds(_x, _y) ? _item : default(T);
		public void SetItemAt(Vector2Int _coords, T _item) => SetItemAt(_coords.x, _coords.y, _item);
		public void SetElementAt(Vector2 _worldPosition, T _item)
		{
			Vector2Int worldPosition = GetXY(_worldPosition);

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
				}
			}
		}

		private void DrawDebugLines()
		{
			Debug.DrawLine(GetWorldPosition(0, m_gridHeight), GetWorldPosition(m_gridWidth, m_gridHeight), Color.red, 50f);
			Debug.DrawLine(GetWorldPosition(m_gridWidth, 0), GetWorldPosition(m_gridWidth, m_gridHeight), Color.red, 50f);
			for (int x = 0; x < m_gridWidth; x++)
			{
				for (int y = 0; y < m_gridWidth; y++)
				{
					Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 50f);
					Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.red, 50f);
				}
			}
		}

		public void DebugCell(int _x, int _y, float _duration, Color _color)
		{
			Debug.DrawLine(GetWorldPosition(_x, _y), GetWorldPosition(_x, _y + 1), _color, _duration);
			Debug.DrawLine(GetWorldPosition(_x, _y + 1), GetWorldPosition(_x + 1, _y + 1), _color, _duration);
			Debug.DrawLine(GetWorldPosition(_x + 1, _y + 1), GetWorldPosition(_x + 1, _y), _color, _duration);
			Debug.DrawLine(GetWorldPosition(_x + 1, _y), GetWorldPosition(_x, _y), _color, _duration);
			Debug.DrawLine(GetWorldPosition(_x, _y), GetWorldPosition(_x + 1, _y + 1), _color, _duration);
			Debug.DrawLine(GetWorldPosition(_x, _y + 1), GetWorldPosition(_x + 1, _y), _color, _duration);
		}

		public Vector3 GetWorldPosition(int _x, int _y) => new Vector3(_x, _y) * m_cellSize + m_gridOrigin;
		public Vector2Int GetXY(Vector3 _worldPosition)
		{
			int x = Mathf.FloorToInt((_worldPosition + m_gridOrigin).x / m_cellSize);
			int y = Mathf.FloorToInt((_worldPosition + m_gridOrigin).y / m_cellSize);

			return new Vector2Int(x, y);

		}
		#endregion
	}
}