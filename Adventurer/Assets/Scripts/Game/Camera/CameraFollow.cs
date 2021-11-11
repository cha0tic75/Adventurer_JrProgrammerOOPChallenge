// ######################################################################
// CameraFollow - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.CameraTools
{
	public class CameraFollow : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Transform m_targetTransform;
		[SerializeField] private float m_smoothTime = 15f;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void FixedUpdate()
		{
			Vector3 targetPosition = new Vector3(m_targetTransform.position.x, m_targetTransform.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_smoothTime * Time.fixedDeltaTime);
		}
		#endregion
	}
}