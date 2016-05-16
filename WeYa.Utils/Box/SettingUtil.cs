/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Windows.Storage;

namespace WeYa.Utils
{
    public class SettingUtil
    {
        private const string KEY_FOLDERNAME = "wellBeing";
        public const string KEY_FOLDER = "test";

        private const string KEY_F_STATIC_PKGNAME = "static_pkg_name";
        private const string KEY_F_STATIC_AGE = "static_pkg_age";
        private const string KEY_F_STATIC_APILEVEL = "static_api_level";
        private const string KEY_F_STATIC_VERCODE = "static_ver_code";
        private const string KEY_F_STATIC_VERNAME = "static_ver_name";
        private const string KEY_F_STATIC_CHANNEL = "static_channel";

        private static readonly SettingUtil instance = new SettingUtil();
        public static SettingUtil getInstance
        {
            get { return instance; }
        }
        private readonly ApplicationDataContainer myDataContainer;

        private SettingUtil()
        {
            myDataContainer = ApplicationData.Current.LocalSettings;
            createContainer();
        }

        /// <summary>
        /// 创建容器
        /// </summary>
        private void createContainer()
        {
            myDataContainer.CreateContainer(KEY_FOLDERNAME, ApplicationDataCreateDisposition.Always);
        }
        /// <summary>
        /// 删除所有数据
        /// </summary>
        private void deleteAllData()
        {
            myDataContainer.DeleteContainer(KEY_FOLDERNAME);
        }
        /// <summary>
        /// 是否含有容器文件夹
        /// </summary>
        /// <returns></returns>
        private bool hasContainer()
        {
            return myDataContainer.Containers.ContainsKey(KEY_FOLDERNAME);
        }
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void setValues<T>(string key, T value)
        {
            if (value == null | hasValues(key))
                return;

            myDataContainer.Values[key] = value;
        }
        /// <summary>
        /// 替换原有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void ReplaceValues<T>(string key, T value)
        {
            if (value == null || !hasValues(key))
                return;

            myDataContainer.Values.Remove(key);
            myDataContainer.Values[key] = value;
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void removeValues(string key)
        {
            myDataContainer.Values.Remove(key);
        }

        /// <summary>
        /// 是否含有键
        /// </summary>
        /// <param name="key">键</param>
        private bool hasValues(string key)
        {
            return myDataContainer.Values.ContainsKey(key);
        }
        /// <summary>
        /// 读取键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T getValues<T>(string key, T defaultValue)
        {
            if (hasValues(key))
            {
                return (T)myDataContainer.Values[key];
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public void saveValues(string key, string pkgName, string apiLevel, int verCode, string verName, string channel)
        {
            if (!hasValues(key))
                return;

            ApplicationDataCompositeValue composite = new ApplicationDataCompositeValue();
            composite[KEY_F_STATIC_AGE] = pkgName;
            composite[KEY_F_STATIC_AGE] = apiLevel;
            composite[KEY_F_STATIC_AGE] = channel;
            composite[KEY_F_STATIC_AGE] = verName;
            composite[KEY_F_STATIC_PKGNAME] = verCode;

            myDataContainer.Values[key] = composite;
        }
    }
}
