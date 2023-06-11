using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

namespace HGH.Common
{
    public static class ToolReflection
    {
        public static FieldInfo[] GetFields(this Type type, BindingFlags bindingAttr, bool inclusionSubclass, Type baseClassRange)
        {
            List<FieldInfo> fieldInfoList = new List<FieldInfo>();
            FieldInfo[] fieldInfos = type.GetFields(bindingAttr);
            fieldInfoList.AddRange(fieldInfos);
            if (inclusionSubclass)
            {
                while ((type = type.BaseType) != baseClassRange)
                {
                    fieldInfoList.AddRange(type.GetFields(bindingAttr));
                }
            }
            return fieldInfoList.ToArray();
        }

        public static FieldInfo[] GetSerializeFields(this Type type, bool inclusionSubclass)
        {
            FieldInfo[] fieldInfos = GetFields(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, inclusionSubclass, typeof(MonoBehaviour));
            return fieldInfos
                .Where(value => value.IsPublic || value.GetCustomAttribute<SerializeField>() != null)
                .ToArray();
        }

        //public static MethodInfo[] GetSerializeMethods(this Type type)
        //{

        //}
    }
}
