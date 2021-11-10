// ######################################################################
// SingletonMonoBehaviour - Generic implementation of a singleton that
//                          derives from MonoBehaviour
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[Tooltip("Tick if this gameobject should persist on scene changes.")]
		[SerializeField] private bool m_dontDestroyOnload = false;
		#endregion

		#region Properties:
		public static T Instance { get; private set; }
		#endregion

		#region MonoBehaiour Callback Method(s):
		protected virtual void Awake()
		{
			if (Instance != null)
			{
				Destroy(gameObject);
				return;
			}

			Instance = this as T;

			if (m_dontDestroyOnload)
			{
				DontDestroyOnLoad(gameObject);
			}
		}
		#endregion
	}
}