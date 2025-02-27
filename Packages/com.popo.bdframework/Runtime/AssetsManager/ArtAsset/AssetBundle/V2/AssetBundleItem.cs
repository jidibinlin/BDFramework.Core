using System.Collections.Generic;

namespace BDFramework.ResourceMgr.V2
{
    /// <summary>
    /// 存储单个资源的数据
    /// </summary>
    public class AssetBundleItem
    {
        public AssetBundleItem(int id, string loadPath, string assetbundlePath, int assetType, int[] dependAssetIds = null)
        {
            this.Id = id;
            this.LoadPath = loadPath;
            this.AssetBundlePath = assetbundlePath;
            this.AssetType = assetType;
            this.DependAssetIds = dependAssetIds;
        }

        /// <summary>
        /// 给各种序列化,用的构造
        /// </summary>
        public AssetBundleItem()
        {
        }

        /// <summary>
        /// 资源Id 
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 资源类型
        /// </summary>
        public int AssetType { get; private set; } = -1;

        /// <summary>
        /// 加载资源路径
        /// 一般为程序调用加载的路径
        /// </summary>
        public string LoadPath { get; private set; } = "";


        /// <summary>
        /// 引用AB的信息
        /// 用以节省配置空间
        /// </summary>
        public int RefABId { get; set; } = 0;

        /// <summary>
        /// ab的资源路径
        /// </summary>
        public string AssetBundlePath { get; private set; } = "";

        /// <summary>
        /// ab hash
        /// 用murmurhash3算法
        /// </summary>
        public string  Hash { get; set; }
        /// <summary>
        /// 混淆
        /// </summary>
        public int Mix { get; set; } = 0;

        /// <summary>
        /// 依赖
        /// </summary>
        public int[] DependAssetIds { get; set; } = new int[] { };
    }
}
