// ######################################################################
// PersistantObjects - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
	public class PersistantObjects : SingletonMonoBehaviour<PersistantObjects>
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private ScreenFader m_screenFader;
		[SerializeField] private SceneHandler m_sceneHandler;
		#endregion

		#region Properties:
		public ScreenFader ScreenFader => m_screenFader;
		public SceneHandler SceneHandler => m_sceneHandler;
		#endregion
	}
}