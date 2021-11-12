// ######################################################################
// MapCaptureEditor - Script description goes here
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
    [CustomEditor(typeof(MapCapture))]
	public class MapCaptureEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			MapCapture myScript = (MapCapture)target;
			if(GUILayout.Button("Capture Map"))
			{
				myScript.DoCapture();
			}
		}
	}

#endif
}