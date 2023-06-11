using UnityEngine;

namespace HGH.Common
{
    /// <summary>
    /// 单例基类
    /// </summary>
    public abstract class Singleton<T> where T : class, new()
    {
        private static T instance;

        protected Singleton()
        {
            if (instance != null)
            {
                Debug.LogError($"{typeof(T)} 类型的单例实例多次创建");
            }
            Init();
        }

        /// <summary>
        /// 实例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {

        }
    }
}