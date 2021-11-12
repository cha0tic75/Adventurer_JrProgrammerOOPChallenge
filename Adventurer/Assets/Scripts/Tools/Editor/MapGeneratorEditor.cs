// ######################################################################
// MapGeneratorEditor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Project.Tools
{
#if UNITY_EDITOR
    [CustomEditor(typeof(MapGenerator))]
	public class MapGeneratorEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			MapGenerator myScript = (MapGenerator)target;
			if(GUILayout.Button("Generate Map"))
			{
				myScript.DoGenerate();
			}
		}
	}
#endif
}