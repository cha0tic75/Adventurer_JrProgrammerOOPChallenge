// ######################################################################
// PathFinding - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.PathFinder
{
    public class PathNode
	{
		#region Public Field(s):
		public int gCost;
		public int hCost;
		public int fCost;
		public PathNode cameFromNode;
		public bool isWalkable;
		#endregion

		#region Internal State Field(s):
		private Grid<PathNode> m_grid;
		public int x { get; private set;}
		public int y { get; private set;}
		#endregion

		#region Constructor(s):
		public PathNode(Grid<PathNode> _grid, int _x, int _y)
		{
			m_grid = _grid;
			x = _x;
			y = _y;
			isWalkable = true;
		}
		#endregion

		#region Public API:
		public override string ToString() => $"{x}, {y}";
		public void CalculateFCost() => fCost = gCost + hCost;
		#endregion
	}

	public class PathFinding
	{
		#region Constant(s):
		private const int MOVE_STRAIGHT_COST = 10;
		private const int MOVE_DIAGONAL_COST = 14;
		#endregion

		#region Internal State Field(s):
		private List<PathNode> m_openList;
		private List<PathNode> m_closedList;

		private static List<Vector2Int> s_cardinalDirections = new List<Vector2Int>()
		{
			new Vector2Int(1, 0), 
			new Vector2Int(-1, 0), 
			new Vector2Int(0, 1), 
			new Vector2Int(0, -1), 
		};
		private static List<Vector2Int> s_ordinalDirections = new List<Vector2Int>()
		{
			new Vector2Int(1, 1), 
			new Vector2Int(-1, 1), 
			new Vector2Int(1, 1), 
			new Vector2Int(1, -1), 
		};
		private static List<Vector2Int> s_allDirections = new List<Vector2Int>()
		{
			s_cardinalDirections[0], s_cardinalDirections[1], s_cardinalDirections[2], s_cardinalDirections[3],
			s_ordinalDirections[0], s_ordinalDirections[1], s_ordinalDirections[2], s_ordinalDirections[3]
		};
		#endregion

		#region Properties:
		public Grid<PathNode> PathfindingGrid { get; private set; }
		#endregion

		#region  Constructor(s):
		public PathFinding(int _width, int _height, float _cellSize)
		{
			PathfindingGrid = new Grid<PathNode>(_width, _height, _cellSize, Vector3.zero, (Grid<PathNode> _g, int _x, int _y) => new PathNode(_g, _x, _y));
		}
		#endregion

		#region Public API:
		public List<PathNode> FindPath(Vector2Int _startCoords, Vector2Int _endCoords) => FindPath(_startCoords.x, _startCoords.y, _endCoords.x, _endCoords.y);
		public List<PathNode> FindPath(int _startX, int _startY, int _endX, int _endY)
		{
			PathNode startNode = PathfindingGrid.GetGridObjectAt(_startX, _startY);
			PathNode endNode = PathfindingGrid.GetGridObjectAt(_endX, _endY);

			m_openList = new List<PathNode>() { startNode };
			m_closedList = new List<PathNode>();

			for (int x = 0; x < PathfindingGrid.GridWidth; x++)
			{
				for (int y = 0; y < PathfindingGrid.GridHeight; y++)
				{
					PathNode pathNode = PathfindingGrid.GetGridObjectAt(x, y);
					pathNode.gCost = int.MaxValue;
					pathNode.CalculateFCost();
					pathNode.cameFromNode = null;
				}
			}
	
			startNode.gCost = 0;
			startNode.hCost = CalculateDistanceCost(startNode, endNode);
			startNode.CalculateFCost();

			while(m_openList.Count > 0)
			{
				PathNode currentNode = GetLowestFCostNode(m_openList);

				if (currentNode == endNode) { return CalculatePath(endNode); }

				m_openList.Remove(currentNode);
				m_closedList.Add(currentNode);

				foreach(var neighborNode in GetNeighborList(currentNode))
				{
					if (m_closedList.Contains(neighborNode)) { continue; }
					if (!neighborNode.isWalkable)
					{
						m_closedList.Add(neighborNode);
						continue;
					}

					int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
					
					if (tentativeGCost < neighborNode.gCost)
					{
						neighborNode.cameFromNode = currentNode;
						neighborNode.gCost = tentativeGCost;
						neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
						neighborNode.CalculateFCost();

						if (!m_openList.Contains(neighborNode))
						{
							m_openList.Add(neighborNode);
						}
					}
				}
			}
	
			return null;
		}

		#endregion

		#region Internally Used Method(s):
		private List<PathNode> CalculatePath(PathNode _endNode)
		{
			List<PathNode> path = new List<PathNode>();
			path.Add(_endNode);

			PathNode currentNode = _endNode;
			while(currentNode.cameFromNode != null)
			{
				path.Add(currentNode.cameFromNode);
				currentNode = currentNode.cameFromNode;
			}

			path.Reverse();
			return path;
		}
		private int CalculateDistanceCost(PathNode a, PathNode b)
		{
			int xDistance = Mathf.Abs(a.x - b.x);
			int yDistance = Mathf.Abs(a.y - b.y);
			int remaining = Mathf.Abs(xDistance - yDistance);

			return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
		}

		private PathNode GetLowestFCostNode(List<PathNode> _pathNodeList)
		{
			PathNode lowestFCostNode = _pathNodeList[0];
			for (int i = 1; i < _pathNodeList.Count; i++)
			{
				if (_pathNodeList[i].fCost < lowestFCostNode.fCost)
				{
					lowestFCostNode = _pathNodeList[i];
				}
			}

			return lowestFCostNode;
		}

		private List<PathNode> GetNeighborList(PathNode _currentNode)
		{
			List<PathNode> neighborList = new List<PathNode>();

			if (_currentNode.x - 1 >= 0)
			{
				neighborList.Add(GetNode(_currentNode.x - 1, _currentNode.y));
				if (_currentNode.y -1 >= 0) { neighborList.Add(GetNode(_currentNode.x - 1, _currentNode.y - 1)); }
				if (_currentNode.y + 1 < PathfindingGrid.GridHeight) { neighborList.Add(GetNode(_currentNode.x - 1, _currentNode.y + 1)); }
			}

			if (_currentNode.x + 1 < PathfindingGrid.GridWidth)
			{
				neighborList.Add(GetNode(_currentNode.x + 1, _currentNode.y));
				if (_currentNode.y -1 >= 0) { neighborList.Add(GetNode(_currentNode.x + 1, _currentNode.y - 1)); }
				if (_currentNode.y + 1 < PathfindingGrid.GridHeight) { neighborList.Add(GetNode(_currentNode.x + 1, _currentNode.y + 1)); }
			}

			if (_currentNode.y -1 >= 0) { neighborList.Add(GetNode(_currentNode.x, _currentNode.y - 1)); }
			if (_currentNode.y + 1 < PathfindingGrid.GridHeight) { neighborList.Add(GetNode(_currentNode.x, _currentNode.y + 1)); }

			return neighborList;
		}

		private PathNode GetNode(int _x, int _y) => PathfindingGrid.GetGridObjectAt(_x, _y);
		private PathNode GetNode(Vector2Int _coords) => GetNode(_coords.x, _coords.y);

		private List<PathNode> GetNeighborListOld(PathNode _currentNode)
		{
			List<PathNode> neighborList = new List<PathNode>();

			foreach(var direction in s_allDirections)
			{
				var possibleNeighborCoord = 
					new Vector2Int(_currentNode.x, _currentNode.y) + direction;
				
				if (PathfindingGrid.IsCoordInGridBounds(possibleNeighborCoord))
				{
					neighborList.Add(PathfindingGrid.GetGridObjectAt(possibleNeighborCoord));
				}
			}

			return neighborList;
		}
		#endregion
	}
}