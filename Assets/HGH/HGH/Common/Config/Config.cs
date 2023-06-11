using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace HGH.Common
{
    /// <summary>
    /// 配置基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Config<T> : MonoBehaviour where T : new()
    {
        [SerializeField]
        private PathType pathType;
        [SerializeField]
        private string localPath;
        [SerializeField]
        private T configData;

        /// <summary>
        /// 配置数据
        /// </summary>
        public T ConfigData => configData;

        protected virtual void Awake()
        {
            configData = ConfigManager.Instance.ReadConfig<T>(ToolPath.GetPath(localPath, pathType));
        }

        public void 读取数据()
        {

        }
    }
}
