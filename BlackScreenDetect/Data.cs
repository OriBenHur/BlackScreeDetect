using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BlackScreenDetect
{
    [Serializable]
    public class Data
    {
        private static readonly string SavePath = Directory.GetCurrentDirectory() + "\\Settings.sd";
        private static Data _instance;
        public List<string> WatchedFolders { get; private set; }
        public string FFmpegBinLib { get; set; }
        public string OutputFolder { get; set; }
        public string Duration { get; set; }
        public  string PixThreshold { get; set; }
        public string PicThreshold { get; set; }

        public static Data Instance => _instance ?? (_instance = Load());

        private Data()
        {
            CheckData();
        }

        private void CheckData()
        {
            if (WatchedFolders == null)
                WatchedFolders = new List<string>();
        }

        public static void Save()
        {
            try
            {
                if (File.Exists(SavePath))
                    File.Delete(SavePath);
            }
            catch (Exception ex)
            {
                $"Cannot delete {SavePath}, {ex.Message}".AsErrorMessage("Serialization error");
                return;
            }
            try
            {
                using (FileStream fileStream = File.OpenWrite(SavePath))
                    new BinaryFormatter().Serialize(fileStream, _instance);
            }
            catch (Exception ex)
            {
                $"Cannot write to {SavePath}, {ex.Message}".AsErrorMessage("Serialization error");
            }
        }

        private static Data Load()
        {
            if (!File.Exists(SavePath))
                return new Data();
            object obj = null;
            try
            {
                using (FileStream fileStream = File.OpenRead(SavePath))
                    obj = new BinaryFormatter().Deserialize(fileStream);
            }
            catch (Exception ex)
            {
                $"Cannot read {SavePath}, {ex.Message}".AsErrorMessage("Deserialization error");
            }
            if ((obj == null ? 1 : (!(obj is Data) ? 1 : 0)) != 0)
            {
                try
                {
                    File.Delete(SavePath);
                }
                catch (Exception)
                {
                    //ignored
                }
                return new Data();
            }
            Data data = obj as Data;
            data?.CheckData();
            return data;
        }
    }
}
