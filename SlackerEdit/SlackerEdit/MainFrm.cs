using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


/*
 * TO DO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 *  * 
 */


namespace SlackerEdit
{
    public partial class MainFrm : Form
    {
        public delegate System.Drawing.Font ModifyFontDelegate(System.Drawing.Font currentFont);

        SectionMgr m_SectionMgr = null;
        const string m_MainTitle = "Slacker 2000 Song Editor";
        
        /// <summary>
        /// 
        /// </summary>
        public MainFrm()
        {
            m_SectionMgr = new SectionMgr();
            this.m_TreeView = new TreeViewEx(m_SectionMgr);
            this.m_EditControl = new RichTextBoxEx(m_SectionMgr);
         
            InitializeComponent();

            this.m_SplitterContainer.Panel1.Controls.Add(this.m_TreeView);
            this.m_SplitterContainer.Panel2.Controls.Add(this.m_EditControl);         
        }
            

        /// <summary>
        /// 
        /// </summary>
        private void OnSplitterMoved(object sender, SplitterEventArgs e)
        {
            ResizeEditWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResizeEditWindow()
        {
            int newWidth = m_SplitterContainer.Panel2.Width + 20;
            int newHeight = (int)(.562 * newWidth);

            if (newHeight < m_SplitterContainer.Panel2.Height)
            {
                m_EditControl.Width = newWidth - (int)(newWidth * .05);
                m_EditControl.Height = newHeight - (int)(newWidth * .05);
            }

            m_EditControl.Left = (m_SplitterContainer.Panel2.Width - m_EditControl.Width) / 2;
            m_EditControl.Top = (m_SplitterContainer.Panel2.Height - m_EditControl.Height) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnMenuExit(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadFontCombo()
        {
            string[] preferedFonts ={
                                    "Arial",
                                    "Courier New",
                                    "MS Sans Serif",
                                    "Times New Roman",
                                    "Impact",
                                    "Comic Sans MS",
                                    "Tahoma"};

            foreach (string fontName in preferedFonts)
            {
                Font fontTester = new Font(fontName, 48, FontStyle.Regular, GraphicsUnit.Pixel);

                if (fontTester.Name == fontName)
                {
                    m_FontToolStripComboBox.Items.Add(fontName);
                }
            }

            m_FontToolStripComboBox.SelectedIndex = 0;

            string firstFont = m_FontToolStripComboBox.SelectedItem.ToString();
            m_EditControl.SetFontFamily(firstFont);
            Font newFont = new Font(firstFont, 48, FontStyle.Regular, GraphicsUnit.Pixel);
            m_EditControl.Font = newFont;
            m_EditControl.SelectionFont = newFont;
        }
              

        /// <summary>
        /// 
        /// </summary>
        private void OnLoad(object sender, EventArgs e)
        {       
            SplashFrm newSplashForm = new SplashFrm();
            newSplashForm.ShowDialog(this);   
                        
            LoadFontCombo();

            //set color to red so it is easily visable but leave the default text color white
            m_PickColorToolStripCombo.SelectedIndex = 2;
            this.Text = m_MainTitle + " - Untitled";
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnResize(object sender, EventArgs e)
        {
           ResizeEditWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnLayout(object sender, LayoutEventArgs e)
        {
            ResizeEditWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        private void TextLargerToolButtonOnClick(object sender, EventArgs e)
        {
            ModifyFontDelegate modifyFontSizeFunc = new ModifyFontDelegate(RichTextBoxEx.IncreaseFontSize);
            ModifyFont(modifyFontSizeFunc);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BoldTextToolButtonOnClick(object sender, EventArgs e)
        {
            ModifyFontDelegate modifyFontSizeFunc = new ModifyFontDelegate(RichTextBoxEx.MakeTextBold);
            ModifyFont(modifyFontSizeFunc);       
        }

        /// <summary>
        /// 
        /// </summary>
        private void ItalicTextToolButtonOnClick(object sender, EventArgs e)
        {
            ModifyFontDelegate modifyFontSizeFunc = new ModifyFontDelegate(RichTextBoxEx.MakeTextItalic);
            ModifyFont(modifyFontSizeFunc);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// 
        private void ModifyFont(ModifyFontDelegate modifyFontDelegate)
        {
          
            if (m_EditControl.SelectionLength > 0)
            {
               m_EditControl.BeginUpdate();
                m_TreeView.BeginUpdate();
                m_EditControl.Focus();
                       
                int startChar = m_EditControl.SelectionStart;
                int numChars = m_EditControl.SelectionLength;
                m_EditControl.SelectionLength = 1;

                bool windowsBug = false;

                for (int i = 1; i <= numChars; i++)
                {
                    windowsBug = false;

                    if (m_EditControl.SelectionFont != null)
                    {
                        if (m_EditControl.SelectionFont.Size == 13)
                        {
                            windowsBug = true;
                        }
                    }

                    if (m_EditControl.SelectionFont == null || i == numChars || windowsBug)
                    {
                        if (m_EditControl.SelectionFont == null || windowsBug)
                        {
                            if (m_EditControl.SelectionLength > 1)
                            {
                                m_EditControl.SelectionLength--;
                                i--;
                            }
                        }                    
                                              
                        System.Drawing.Font currentFont = m_EditControl.SelectionFont;
                        m_EditControl.SelectionFont = modifyFontDelegate(currentFont);                        
                        m_EditControl.SelectionStart = m_EditControl.SelectionStart + m_EditControl.SelectionLength ;
                        m_EditControl.SelectionLength = 0;
                    }

                    m_EditControl.SelectionLength++;
                }
                
                m_EditControl.SelectionStart = startChar;
                m_EditControl.SelectionLength = numChars;
                m_EditControl.EndUpdate();
                m_TreeView.EndUpdate();     
            }            
          
        }

        /// <summary>
        /// 
        /// </summary>
        private void TextSmallerToolButtonOnClick(object sender, EventArgs e)
        {
            ModifyFontDelegate modifyFontSizeFunc = new ModifyFontDelegate(RichTextBoxEx.ReduceFontSize);
            ModifyFont(modifyFontSizeFunc);                     
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void FontTypeComboOnClose(object sender, EventArgs e)
        {
            m_EditControl.Focus();
            if (m_EditControl.SelectionFont != null)
            {
                string fontName = m_FontToolStripComboBox.SelectedItem.ToString();
                m_EditControl.SetFontFamily(fontName);
               
                System.Drawing.Font currentFont = m_EditControl.SelectionFont;
                m_EditControl.SelectionFont = new Font(fontName, currentFont.Size, currentFont.Style);
                m_EditControl.Select(m_EditControl.SelectionStart, 0);
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        private void TextColorToolButtonOnClick(object sender, EventArgs e)
        {
            string name = m_PickColorToolStripCombo.SelectedItem.ToString();
            if (name != "")
            {
                m_EditControl.SelectionColor = Color.FromName(name);
                m_EditControl.Select(m_EditControl.SelectionStart, 0);
            }         
        }

        /// <summary>
        /// 
        /// </summary>
        private void TextColorToolButtonPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = null;

            string name = m_PickColorToolStripCombo.SelectedItem.ToString();

            if (name == "")
            {
                b = new SolidBrush(Color.FromName("black"));
            }
            else
            {
                b = new SolidBrush(Color.FromName(name));
            }
          
            g.FillRectangle(b, 4, 17, 14, 4);  
        }

      

        /// <summary>
        /// 
        /// </summary>
        private void TextLeftToolButtonOnClick(object sender, EventArgs e)
        {
            m_EditControl.SelectionAlignment = HorizontalAlignment.Left;
        }

        /// <summary>
        /// 
        /// </summary>
        private void TextCenterToolButtonOnClick(object sender, EventArgs e)
        {
            m_EditControl.SelectionAlignment = HorizontalAlignment.Center;
        }

        /// <summary>
        /// 
        /// </summary>
        private void TextRightToolButtonOnClick(object sender, EventArgs e)
        {
            m_EditControl.SelectionAlignment = HorizontalAlignment.Right;
        }
         
        /// <summary>
        /// 
        /// </summary>
        private void DeleteSection()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the section?", "Delete Section", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                m_SectionMgr.DeleteSection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddSectionToolStripButtonOnClick(object sender, EventArgs e)
        {
            m_SectionMgr.AddSection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddSectionMenuOnClick(object sender, EventArgs e)
        {
            m_SectionMgr.AddSection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteSectionToolStripButtonOnClick(object sender, EventArgs e)
        {
            DeleteSection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteSectionMenuOnClick(object sender, EventArgs e)
        {
            DeleteSection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FileSaveMenuOnClick(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Slacker Files (*.slk)|*.slk|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save a Slacker File";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;                 
                 try
                 {
                    StreamWriter fileStream = new StreamWriter(saveFileDialog.OpenFile());
                    if (fileStream != null)
                    {
                   
                            m_SectionMgr.SaveFile(fileStream);
                            fileStream.Close();
                            this.Text = m_MainTitle + " - " + Path.GetFileName(saveFileDialog.FileName);                                       
                    }
                 }
                 catch (System.Xml.XmlException e)
                 {
                     MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                 }
                 catch (System.IO.IOException e)
                 {
                     MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 }

                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RenameSectionMenuOnClick(object sender, EventArgs e)
        {
            m_TreeView.RenameSection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveFileToolStripButtonOnClick(object sender, EventArgs e)
        {
            SaveFile();
        }

              
        /// <summary>
        /// 
        /// </summary>
        private void NewFileToolStripButtonOnClick(object sender, EventArgs e)
        {
            NewFile();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FileNewMenuOnClick(object sender, EventArgs e)
        {
            NewFile();
        }

         /// <summary>
        /// 
        /// </summary>
        private void NewFile()
        {
            DialogResult result = System.Windows.Forms.DialogResult.Yes;
            if (m_SectionMgr.DocumentModified == true)
            {
                result = MessageBox.Show("Do you want to save the current file?", "New File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveFile();
                }
            }

            this.Text = m_MainTitle + " - Untitled" ;
            this.Cursor = Cursors.WaitCursor;
            m_SectionMgr.ResetAll();
            this.Cursor = Cursors.Default;     
      
        }

        /// <summary>
        /// 
        /// </summary>
        private void exportSetList()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Export a Set List";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    StreamWriter fileStream = new StreamWriter(saveFileDialog.OpenFile());
                    if (fileStream != null)
                    {
                        List<string> nodeList = new List<string>();
                        this.m_TreeView.GetNodeList(ref nodeList);

                        foreach (string currentSong in nodeList)
                        {
                            fileStream.Write(currentSong + Environment.NewLine);                           
                        }

                        fileStream.Close();                        
                    }
                }
                catch (System.Xml.XmlException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.Cursor = Cursors.Default;
            }            
       
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenFile()
        {  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Slacker Files (*.slk)|*.slk|All Files (*.*)|*.*";
            openFileDialog.Title = "Open a Slacker File";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            try
            {
                DialogResult result = System.Windows.Forms.DialogResult.Yes;
                if (m_SectionMgr.DocumentModified == true)
                {
                    result = MessageBox.Show("Do you want to save the current file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveFile();
                    }
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        m_TreeView.BeginUpdate(); 
                        m_SectionMgr.ResetAll();
                        m_TreeView.EndUpdate();                                               
                     
                        this.Text = m_MainTitle + " - " + openFileDialog.SafeFileName;
                        m_SectionMgr.OpenFile(openFileDialog.FileName);     
                    }
                }
            }
            catch (System.Xml.XmlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenFileToolStripButtonOnClick(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FileOpenMenuOnClick(object sender, EventArgs e)
        {
            OpenFile();

        }

        /// <summary>
        /// 
        /// </summary>
        private void HelpAboutMenuOnClick(object sender, EventArgs e)
        {
            AboutFrm aboutForm = new AboutFrm();
            aboutForm.ShowDialog(this);      
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportSetList();
        }

        private void m_ExportFileToolStripButton_Click(object sender, EventArgs e)
        {
            exportSetList();
        }
    }
}
