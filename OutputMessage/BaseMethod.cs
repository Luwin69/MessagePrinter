using System;
using System.Collections.Generic;
using System.Text;

namespace OutputMessage
{
    public static class BaseMethod
    {
        internal List<string> keyWords = new List<string>();
        internal List<string> filePath = new List<string>();
        public static void WriteLine(string path, string lineText)
        {
            if (path == null) return;
            FileStream wl = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader textWriter = new StreamReader(wl, Encoding.Default);
            textWriter.Write(lineText);
        }
        public static string GetFilePath(string key)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.txt|*.txt";
            dlg.Title = text + "存储路径";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            return null;
        }
        public static void SetFilePath()
        {
            for (int i = 0; i < keyWords.Count; i++)
            {
                filePath.Add(GetFilePath(keyWords[i]));
            }
        }
        public static void OpenKeyWordsFile(string path)
        {
            StreamReader textReader = new StreamReader(path, Encoding.Default);
            string keyWord = "";
            while (true)
            {
                string textLine = textReader.ReadLine();
                if (textLine != null)
                {
                    keyWords.Add(textLine);
                }
                else
                {
                    break;
                }
            }
            textReader.Close();
        }
    }
}
