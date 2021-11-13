// ######################################################################
// PathFinding - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Game.AIPathFinding
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
}