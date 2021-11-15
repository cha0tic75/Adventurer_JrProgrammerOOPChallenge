// ######################################################################
// ExtensionMethods - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public static class ExtensionMethods
	{
		public static bool IsNaN(this Vector3 _value)
		{
			return float.IsNaN(_value.x) || float.IsNaN(_value.y) || float.IsNaN(_value.z);
		}

		public static bool IsNaN(this Vector2 _value)
		{
			return float.IsNaN(_value.x) || float.IsNaN(_value.y); 
		}
	}
}