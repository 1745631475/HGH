using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using Newtonsoft.Json;

namespace HGH.Common
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public class ConfigManager : Singleton<ConfigManager>
    {
        private readonly Dictionary<string, object> configDic = new Dictionary<string, object>();
        private readonly JsonSerializerSettings jsonSetting = new JsonSerializerSettings();

        /// <summary>
        /// Json序列化设置
        /// </summary>
        public JsonSerializerSettings JsonSetting => jsonSetting;

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            jsonSetting.Formatting = Formatting.Indented;
            jsonSetting.NullValueHandling = NullValueHandling.Include;
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <param name="localPath">局部路径</param>
        /// <param name="pathType">路径类型</param>
        /// <returns>配置数据</returns>
        public T GetConfig<T>(string localPath, PathType pathType = PathType.streamingAssets) where T : new()
        {
            string path = ToolPath.GetPath(localPath, pathType);
            if (configDic.ContainsKey(path))
            {
                object obj = configDic[path];
                if (obj is T config)
                {
                    return config;
                }
                else
                {
                    Debug.LogError("同路径下已经存在不同类型的配置");
                    return default(T);
                }
            }
            else
            {
                T config = ReadConfig<T>(path);
                configDic.Add(path, config);
                return config;
            }
        }
        internal T ReadConfig<T>(string path) where T : new()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                T config = JsonConvert.DeserializeObject<T>(json);
                return config;
            }
            else
            {
                T config = new T();
                WriteConfig(path, config);
                return config;
            }
        }
        internal void WriteConfig<T>(string path, T data)
        {
            string folderName = Path.GetDirectoryName(path);
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
            string json = JsonConvert.SerializeObject(data, jsonSetting);
            File.WriteAllText(path, json);
        }
    }
}
