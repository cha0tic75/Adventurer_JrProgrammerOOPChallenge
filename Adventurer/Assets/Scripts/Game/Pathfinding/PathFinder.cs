// ######################################################################
// PathFindingMonoBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Game.AIPathFinding
{
    public class PathFinder : SingletonMonoBehaviour<PathFinder>
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private int m_width;
		[SerializeField] private int m_height;
		[SerializeField] private float m_cellSize = 1f;
        [SerializeField] private LayerMask m_colliderLayer;
        [SerializeField] private bool m_drawDebug;
		#endregion

		#region Internal State Field(s):
		private PathFinding m_grid;
		#endregion

		#region Properties:
		public PathFinding Grid => m_grid;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
            BuildGrid();
            if (m_drawDebug) { DrawDebugMap(); }
		}
		#endregion

        #region Internally Used Method(s):
		private void BuildGrid()
		{			
			m_grid = new PathFinding(m_width, m_height, m_cellSize);

			for (int x = 0; x < m_grid.PathfindingGrid.GridWidth; x++)
			{
				for (int y = 0; y < m_grid.PathfindingGrid.GridHeight; y++)
				{	
					Vector3 position = m_grid.PathfindingGrid.GetWorldPosition(x,y);
					float halfCellSize = m_cellSize * 0.5f;
					position += new Vector3(halfCellSize, halfCellSize);

					bool result = Physics2D.OverlapCircle(position, halfCellSize, m_colliderLayer);

					m_grid.PathfindingGrid.GetGridObjectAt(x, y).isWalkable = !result;
				}
			}
		}

        private void DrawDebugMap()
        {
            foreach(var cell in m_grid.PathfindingGrid.GridContents)
            {
                Color color = (cell.isWalkable) ? Color.green : Color.red;
                m_grid.PathfindingGrid.DebugCell(cell.x, cell.y, 100f, color);
            }
        }
        #endregion
	}
}