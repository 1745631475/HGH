using HGH.Editor;

using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEditor.Localization.Editor;

using UnityEngine;

namespace HGH.Common
{
    [CustomEditor(typeof(Config<>), true)]
    public class ConfigEditor : HInspector
    {

    }
}
