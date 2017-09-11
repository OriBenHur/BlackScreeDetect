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
        public string FontName { get; set; }
        public string FontSize { get; set; }
        public string FontStyle { get; set; }

        public bool PlaySounds { get; set; } = true;
        public bool NoMb { get; set; }
        public bool Debug { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }


        public Color LogBackColor { get; set; }
        public Color RegularColor { get; set; }
        public Color SuccessColor { get; set; }
        public Color WarrningColor { get; set; }
        public Color ErrorColor { get; set; }
        public Color InfoColor { get; set; } 
        public Color IsBoldColor { get; set; }
        public Color IsItalicColor { get; set; }
        public Color IsUnderlineColor { get; set; }

        public Font LogFont { get; set; }


        public Color BackColor { get; set; } 
        public Color ForeColorColor { get; set; }
        public bool Large { get; set; } = true;
        public bool Medium { get; set; }
        public bool Small { get; set; }
        public int Opacity { get; set; } = 100;
        public int LoadX { get; set; }
        public int LoadY { get; set; }
        public int LoadW { get; set; } = 256;
        public int LoadH { get; set; } = 256;
        public string PickItem { get; set; } 


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
                Duration = "0.2";

            if (string.IsNullOrEmpty(PicThreshold))
                PicThreshold = "0.98";

            if (string.IsNullOrEmpty(PixThreshold))
                PixThreshold = "0";

            if (string.IsNullOrEmpty(FontSize))
                FontSize = "11";

            if (string.IsNullOrEmpty(FontName))
                FontName = "Microsoft Sans Serif";

            if (string.IsNullOrEmpty(PickItem))
                PickItem = "Transparent Background";

            if (string.IsNullOrEmpty(FontStyle))
            {
                FontStyle = "";
            }

            if (LogBackColor.IsEmpty)
                LogBackColor = Color.FromArgb(0, 36, 86);

            if (BackColor.IsEmpty)
                BackColor = Color.Black;

            if(ForeColorColor.IsEmpty)
                ForeColorColor = Color.FromArgb(5, 5, 5);

            if (RegularColor.IsEmpty)
                RegularColor = Color.White;

            if (SuccessColor.IsEmpty)
                SuccessColor = Color.Green;

            if(WarrningColor.IsEmpty)
                WarrningColor = Color.Gold;

            if (ErrorColor.IsEmpty)
                ErrorColor = Color.Red;

            if(InfoColor.IsEmpty)
                InfoColor = Color.BlueViolet;

            if(LogFont == null)
                LogFont = new Font("Microsoft Sans Serif", 11.25F);

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
