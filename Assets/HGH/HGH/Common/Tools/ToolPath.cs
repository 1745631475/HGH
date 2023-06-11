using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace HGH.Common
{
    public static class ToolPath
    {
        public static string GetPath(string localPath, PathType pathType, string extension = ".json")
        {
            switch (pathType)
            {
                case PathType.streamingAssets:
                    return $"{Application.streamingAssetsPath}/{localPath}{extension}";
                case PathType.persistentData:
                    return $"{Application.persistentDataPath}/{localPath}{extension}";
                case PathType.temporaryCache:
                    return $"{Application.temporaryCachePath}/{localPath}{extension}";
                default:
                    return $"{Application.streamingAssetsPath}/{localPath}{extension}";
            }
        }
    }
}
