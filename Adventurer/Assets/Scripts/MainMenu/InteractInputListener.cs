// ######################################################################
// InteractInputListener - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Input;
using UnityEngine;

namespace Project.MainMenu
{
	public class InteractInputListener : MonoBehaviour
	{
		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => PlayerInputHandler.Instance.OnInteractInputActionEvent += InputHandler_OnInteractInputActionCallback;

        private void OnDisable() => PlayerInputHandler.Instance.OnInteractInputActionEvent -= InputHandler_OnInteractInputActionCallback;
		#endregion

		#region Callback(s):
        private void InputHandler_OnInteractInputActionCallback(bool _state)
        {
            if (!_state) { return; }
			PersistantObjects.Instance.ScreenFader.OnFadeCoroutineCompletedEvent += ScreenFader_OnFadeCoroutineCompletedCallback;
			PersistantObjects.Instance.ScreenFader.DoFadeOut(1f);
        }

		private void ScreenFader_OnFadeCoroutineCompletedCallback()
		{
			PersistantObjects.Instance.ScreenFader.OnFadeCoroutineCompletedEvent -= ScreenFader_OnFadeCoroutineCompletedCallback;
			PersistantObjects.Instance.SceneHandler.LoadScene(GameScene.Game);
			PersistantObjects.Instance.ScreenFader.DoFadeIn(0.3f);
		}
		#endregion
	}
}