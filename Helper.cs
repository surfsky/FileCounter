using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileMerger
{
    /// <summary>
    /// 静态辅助方法
    /// </summary>
    static class Helper
    {
        /// <summary>获取程序版本号</summary>
        public static string GetVersion()
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Revision);
        }

        /// <summary>文本拆分成数组</summary>
        public static string[] ToArray(this string text)
        {
            return text.Replace(" ", "")
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Replace("\t", "")
                    .Split('|', ',', ';');
        }

        /// <summary>文本为空</summary>
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>转化为布尔</summary>
        public static bool ToBool(this string text)
        {
            if (!text.IsEmpty() && text.ToLower() == "true")
                return true;
            return false;
        }


        /// <summary>文本是注释行</summary>
        public static bool IsCommentLine(this string text)
        {
            if (text.IsEmpty())
                return false;
            text = text.TrimStart();
            return (text.StartsWith("//") || text.StartsWith("#"));
        }
    }
}
