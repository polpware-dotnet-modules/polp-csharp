
namespace Polpware.AspNetCore.Framework.Data
{
    /// <summary>
    /// Represents default values related to data settings
    /// </summary>
    public static class NopDataSettingsDefaults
    {
        /// <summary>
        /// Gets a path to the file that contains data settings
        /// </summary>
        public static string FilePath => "~/App_Data/dataSettings.json";
    }
}
