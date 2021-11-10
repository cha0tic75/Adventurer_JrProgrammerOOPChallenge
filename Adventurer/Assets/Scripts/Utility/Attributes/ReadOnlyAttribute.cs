// ######################################################################
// ReadOnlyAttribute - Define an attribute that can be used to protect manual changes in inspector.
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

#if UNITY_EDITOR
#endif
using UnityEngine;

namespace Project
{
    public class ReadOnlyAttribute : PropertyAttribute { }
}