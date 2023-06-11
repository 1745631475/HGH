using UnityEngine;
using System.Collections;

namespace HGH.Common
{
    /// <summary>
    /// 单例基类
    /// </summary>
    public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// 实例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name);
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 父类Awake请保留
        /// </summary>
        protected virtual void Awake()
        {
            StartCoroutine(MonitorSingleton());
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {

        }
        private IEnumerator MonitorSingleton()
        {
            yield return new WaitForSeconds(0.1f);
            while (instance == null)
            {
                yield return new WaitForSeconds(0.5f);
            }
            if (instance == this)
            {
                Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}