using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackerEdit
{
    public class Section
    {
        public Action OnDataChanged;

        /// <summary>
        /// 
        /// </summary>
        int m_Index = -1;
        public int Index
        {
            get
            {
                return m_Index;
            }
            set
            {
                m_Index = value;              
            }
        }


        /// <summary>
        /// 
        /// </summary>
        string m_Title = "";
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
                if (OnDataChanged != null)
                {
                    OnDataChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        string m_RtfData = "";
        public string RtfData
        {
            get
            {
                return m_RtfData;
            }
            set
            {
                m_RtfData = value;

                if (OnDataChanged != null)
                {
                    OnDataChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Section(string rtfData ,string szTitle)
        {
            m_RtfData = rtfData;
            m_Title = szTitle;
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetHtml()
        {

            MarkupConverter.MarkupConverter markupConverter = new MarkupConverter.MarkupConverter();
            string szContents = markupConverter.ConvertRtfToHtml(RtfData);
           
            if (szContents.IndexOf("<P STYLE") >= 0)
            {
                int dataStart = szContents.IndexOf("<DIV", 0);
                dataStart = szContents.IndexOf(">", dataStart);
                szContents = szContents.Remove(0, dataStart + 1);
                szContents = szContents.Trim();

                szContents = szContents.Replace("<P />", "");
                szContents = szContents.Replace("</DIV>", "");
                szContents = szContents.Replace("\n", "");
                szContents = szContents.Replace("\r", "");
                szContents = szContents.Replace("\t", "");
                szContents = szContents.Replace("'", "&rsquo;");
                szContents = szContents.Replace("’", "&rsquo;");
                szContents = szContents.Replace("‘", "&rsquo;");
                szContents = szContents.Replace("`", "&rsquo;");
                szContents = szContents.Replace("…", "...");
                
                szContents = szContents.Trim();
                
                szContents = szContents.Replace("<P", "<lyricLine><![CDATA[<P");
                szContents = szContents.Replace("</P>", "</P>]]></lyricLine>");
                
            }
            else//handle empty section
            {
                szContents = szContents.Replace("<DIV", "<P");
                szContents = szContents.Replace("<P />", "</P>");
                szContents = szContents.Replace("</DIV>", "");
                szContents = szContents.Replace("color:#000000", "color:#ffffff");          
                
                szContents = "<lyricLine><![CDATA[" + szContents + "]]></lyricLine>";        
            }         

            return szContents;
        }
    }
}
