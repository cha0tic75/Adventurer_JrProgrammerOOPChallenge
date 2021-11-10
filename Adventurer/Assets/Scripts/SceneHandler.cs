// ######################################################################
// SceneHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project
{
	public enum GameScene
	{
		MainMenu = 0,
		Game = 1,
	}

	public class SceneHandler : MonoBehaviour
	{	
		#region Public API:
		public void LoadScene(GameScene _gameScene) => SceneManager.LoadScene((int)_gameScene);
		#endregion
	}
}