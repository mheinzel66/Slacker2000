using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SlackerEdit
{
    public class SectionMgr
    {
        public Action OnDataChanged;
        public Action OnAddSection;
        public Action OnDeleteSection;
        public Action OnResetAll;

        List<Section> m_Sections = null ;       
        Section m_CurrentSection = null;
        bool m_DocumentModified = false;

        /// <summary>
        /// 
        /// </summary>
        public bool DocumentModified
        {
            get
            {
                return m_DocumentModified;
            }
            set
            {
                m_DocumentModified = value;              
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Section CurrentSection
        {
            get
            {
                return m_CurrentSection;
            }
            set
            {
                m_CurrentSection = value;               
                OnDataChanged();
            }
        }
             
        /// <summary>
        /// 
        /// </summary>
        public SectionMgr()
        {
            m_Sections = new List<Section>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSection(string rtfData,string title)
        {
            Section section = new Section(rtfData,title);
            m_Sections.Add(section);
            m_CurrentSection = section;
            m_DocumentModified = true;
            OnAddSection();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetAll()
        {
            List<Section> sections = new  List<Section>(m_Sections);                                          
            m_Sections.Clear();
            m_CurrentSection = null;
            m_DocumentModified = false;
            OnResetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSection()
        {          
            string title = "Untitled Section";
            AddSection("", title);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteSection()
        {
            if (m_CurrentSection != null)
            {
                m_Sections.Remove(m_CurrentSection);
                m_CurrentSection = null;
                m_DocumentModified = true;            
                OnDeleteSection();              
            }
        }             

        /// <summary>
        /// 
        /// </summary>
        public void SaveFile(System.IO.StreamWriter fileStream)
        {

            try
            {
                List<Section> orderedSections = new List<Section>(m_Sections.OrderBy(x => x.Index));

                string fileText = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>  <songs>";

                foreach (Section currentSection in orderedSections)
                {
                    string szSectionTitle = currentSection.Title;
                    int i = currentSection.Index;

                    szSectionTitle = szSectionTitle.Replace("'", "&apos;");
                    fileText += "<song title='" + szSectionTitle + "'>";
                    string sectionText = currentSection.GetHtml();

                    fileText += sectionText;
                    fileText += "</song>";
                }

                fileText += "</songs>";

                //  Console.WriteLine(fileText);
                fileStream.Write(fileText);
                fileStream.Close();
                m_DocumentModified = false;
            }
            catch (System.Xml.XmlException e)
            {
                throw;
            }
            catch (System.IO.IOException e)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpenFile(string szFilePath)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(szFilePath);
                MarkupConverter.MarkupConverter markupConverter = new MarkupConverter.MarkupConverter();
        
                string szSectionData = "";
                string szSectionTitle = "";                         

                while (reader.Read())
                {
                    if (reader.Name == "lyricLine" && reader.NodeType == XmlNodeType.Element)
                    {
                        szSectionData += reader.ReadString();
                    }
                    else if (reader.Name == "song" && reader.NodeType == XmlNodeType.Element)
                    {
                        szSectionTitle = reader.GetAttribute("title");
                    }
                    else if (reader.Name == "song" && reader.NodeType == XmlNodeType.EndElement)
                    {
                        szSectionData = szSectionData.Replace("&rsquo;", "'");
                        string szConvertedSectionData = markupConverter.ConvertHtmlToRtf(szSectionData);
                        AddSection(szConvertedSectionData, szSectionTitle);
                        szSectionData = "";
                        szSectionTitle = "";
                    }
                }

                reader.Close();
                m_DocumentModified = false;  
            }
            catch (XmlException e)
            {
                throw;
            }
            catch (System.IO.IOException e)
            {
                throw;
            }             
        }
        
    }
   
}