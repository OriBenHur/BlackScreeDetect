using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

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
        public string PixThreshold { get; set; }
        public string PicThreshold { get; set; }
        public bool PlaySounds { get; set; } = true;
        public bool X256 { get; set; } = true;
        public bool X128 { get; set; }
        public bool X64 { get; set; }
        public int Opacity { get; set; } = 100;
        public int LoadX { get; set; }
        public int LoadY { get; set; }
        public int LoadW { get; set; } = 256;
        public int LoadH { get; set; } = 256;


        public static Data Instance => _instance ?? (_instance = Load());

        private Data()
        {
            CheckData();
        }

        private void CheckData()
        {
            if (WatchedFolders == null)
                WatchedFolders = new List<string>();

            if (string.IsNullOrEmpty(Duration))
                Duration = "1";


            if (string.IsNullOrEmpty(PicThreshold))
                PicThreshold = "0.98";

            if (string.IsNullOrEmpty(PixThreshold))
                PixThreshold = "0";
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
                using (var fileStream = File.OpenWrite(SavePath))
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
                using (var fileStream = File.OpenRead(SavePath))
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
            var data = obj as Data;
            data?.CheckData();
            return data;
        }
    }
}
