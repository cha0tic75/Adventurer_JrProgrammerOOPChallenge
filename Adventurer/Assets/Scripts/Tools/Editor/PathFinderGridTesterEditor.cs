// ######################################################################
// PathFinderEditor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using Project.Game;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Project.Tools
{
#if UNITY_EDITOR
    [CustomEditor(typeof(PathFinderGridTester))]
	public class PathFinderGridTesterEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			PathFinderGridTester myScript = (PathFinderGridTester)target;
			if(GUILayout.Button("Build Grid"))
			{
				myScript.BuildGrid();
			}
		}
	}
#endif
}