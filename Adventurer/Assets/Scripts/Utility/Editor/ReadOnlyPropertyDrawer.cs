// ######################################################################
// ReadOnlyPropertyDrawer - Define the property drawer for the ReadOnlyAttribute.
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Project
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer 
    {
        #region Public API:
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUI.GetPropertyHeight(property, label, true);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
        #endregion
    }
#endif
}