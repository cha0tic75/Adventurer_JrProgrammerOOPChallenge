// ######################################################################
// PathFindingMonoBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.PathFinder
{
    public class PathFindingMonoBehaviour : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private int m_width;
		[SerializeField] private int m_height;
		[SerializeField] private float m_cellSize = 1f;
        [SerializeField] private LayerMask m_colliderLayer;
        [SerializeField] private bool m_drawDebug;
		#endregion

		#region Internal State Field(s):
		public PathFinding PathFinding { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
            BuildGrid();
            if (m_drawDebug) { DrawDebugMap(); }
            RunTest();
		}
		#endregion

        #region Public API:
        // public List<Vector3> GetPath(Vector3 _start, Vector3 _end)
        // {

        // }
        #endregion

        #region Internally Used Method(s):
		private void BuildGrid()
		{			
			PathFinding = new PathFinding(m_width, m_height, m_cellSize);

			for (int x = 0; x < PathFinding.PathfindingGrid.GridWidth; x++)
			{
				for (int y = 0; y < PathFinding.PathfindingGrid.GridHeight; y++)
				{	
					Vector3 position = PathFinding.PathfindingGrid.GetWorldPosition(x,y);
					float halfCellSize = m_cellSize * 0.5f;
					position += new Vector3(halfCellSize, halfCellSize);

					bool result = Physics2D.OverlapPoint(position, m_colliderLayer);

					PathFinding.PathfindingGrid.GetGridObjectAt(x, y).isWalkable = !result;
				}
			}
		}

        private void DrawDebugMap()
        {
            foreach(var cell in PathFinding.PathfindingGrid.GridContents)
            {
                Color color = (cell.isWalkable) ? Color.green : Color.red;
                PathFinding.PathfindingGrid.DebugCell(cell.x, cell.y, 100f, color);
            }
        }

        private void RunTest()
        {
            Vector2Int start = new Vector2Int(2, 2);
            Vector2Int end = new Vector2Int(22, 37);

            PathFinding.PathfindingGrid.DebugCell(start, 100f, Color.blue);
            PathFinding.PathfindingGrid.DebugCell(end, 100f, Color.white);
            
            StartCoroutine(DisplayPathCoroutine(PathFinding.FindPath(start, end), new WaitForSeconds(0.05f)));
        }
        #endregion

        #region Coroutine(s):
        private IEnumerator DisplayPathCoroutine(List<PathNode> _path, WaitForSeconds _wfs)
        {
            if (_path == null)
            {
                Debug.Log("No Path!"); 
                yield break; 
            }
    
            foreach(var path in _path)
            {
                PathFinding.PathfindingGrid.DebugCell(path.x, path.y, 100f, Color.red);

                yield return _wfs;
            }
        }
        #endregion
	}
}