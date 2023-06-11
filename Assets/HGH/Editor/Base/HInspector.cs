using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using HGH.Common;

namespace HGH.Editor
{
    public class HInspector : UnityEditor.Editor
    {
        public sealed override void OnInspectorGUI()
        {
            DoDrawDefaultInspector();
        }
        private bool DoDrawDefaultInspector()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.UpdateIfRequiredOrScript();
            OnDrawBeginGUI();
            OnDrawGUI();
            OnDrawEndGUI();
            serializedObject.ApplyModifiedProperties();
            return EditorGUI.EndChangeCheck();
        }
        /// <summary>
        /// 头部GUI绘制
        /// </summary>
        public virtual void OnDrawBeginGUI()
        {
            SerializedProperty m_Script = serializedObject.FindProperty("m_Script"); ;
            using (new EditorGUI.DisabledGroupScope(true))
            {
                EditorGUILayout.PropertyField(m_Script, true);
            }
        }
        /// <summary>
        /// 尾部GUI绘制
        /// </summary>
        public virtual void OnDrawEndGUI()
        {

        }
        /// <summary>
        /// GUI绘制
        /// </summary>
        public virtual void OnDrawGUI()
        {
            DrawDefaultGUI();
        }
        /// <summary>
        /// 绘制默认的GUI
        /// </summary>
        public void DrawDefaultGUI()
        {
            SerializedProperty property = serializedObject.GetIterator();
            bool expanded = true;
            while (property.NextVisible(expanded))
            {
                if (property.propertyPath != "m_Script")
                {
                    EditorGUILayout.PropertyField(property, true);
                }
                expanded = false;
            }
        }
    }
}
