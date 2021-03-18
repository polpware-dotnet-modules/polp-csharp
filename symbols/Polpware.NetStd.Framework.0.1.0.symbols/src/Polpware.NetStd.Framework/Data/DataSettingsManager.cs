using Newtonsoft.Json;
using Polpware.NetStd.Framework.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polpware.NetStd.Framework.Infrastructure;

namespace Polpware.NetStd.Framework.Data
{
    public class DataSettingsManager
    {

        #region Methods

        /// <summary>
        /// Load data settings
        /// </summary>
        /// <param name="filePath">File path; pass null to use the default settings file</param>
        /// <param name="reloadSettings">Whether to reload data, if they already loaded</param>
        /// <param name="fileProvider">File provider</param>
        /// <returns>Data settings</returns>
        public static T LoadSettings<T>(INopFileProvider fileProvider, string filePath, bool reloadSettings = false)
            where T: class, new()
        {
            if (!reloadSettings && Singleton<T>.Instance != null)
                return Singleton<T>.Instance;

            //check whether file exists
            if (!fileProvider.FileExists(filePath))
            {
                    return new T();
            }

            var text = fileProvider.ReadAllText(filePath, Encoding.UTF8);
            if (string.IsNullOrEmpty(text))
                return new T();

            //get data settings from the JSON file
            Singleton<T>.Instance = JsonConvert.DeserializeObject<T>(text);

            return Singleton<T>.Instance;
        }

        /// <summary>
        /// Save data settings to the file
        /// </summary>
        /// <param name="settings">Data settings</param>
        /// <param name="fileProvider">File provider</param>
        public static void SaveSettings<T>(INopFileProvider fileProvider, T settings, string filePath)
            where T : class, new()
        {
            Singleton<T>.Instance = settings ?? throw new ArgumentNullException(nameof(settings));

            //create file if not exists
            fileProvider.CreateFile(filePath);

            //save data settings to the file
            var text = JsonConvert.SerializeObject(Singleton<T>.Instance, Formatting.Indented);
            fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }


        #endregion

    }
}
