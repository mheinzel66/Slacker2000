using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices; 

namespace SlackerEdit
{
    
    public partial class RichTextBoxEx : System.Windows.Forms.RichTextBox
    {

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int WM_SETREDRAW = 0x0b; 

        SectionMgr m_SectionMgr = null;
    
         /// <summary>
        /// 
        /// </summary>
        public RichTextBoxEx(SectionMgr sectionMgr)
        {
            this.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "m_RichTextBox";
            this.Size = new System.Drawing.Size(739, 487);
            this.TabIndex = 0;
            this.Text = "";
            this.Visible = false;                                         
            this.SelectionColor = Color.FromName("white");
            this.ForeColor = this.SelectionColor;                    
            sectionMgr.OnDataChanged += UpdateView;
            m_SectionMgr = sectionMgr;

            this.TextChanged += new EventHandler(OnTextChanged);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void BeginUpdate() 
        { 
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero); 
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndUpdate() 
        { 
           SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);  
           this.Invalidate(); 
        } 
        

        /// <summary>
        /// 
        /// </summary>
        private void OnTextChanged(object sender, EventArgs e)
        {
            if (m_SectionMgr.CurrentSection != null)
            {
                if (m_SectionMgr.CurrentSection.RtfData != null)
                {
                    m_SectionMgr.CurrentSection.RtfData = this.Rtf;               
                }
                m_SectionMgr.DocumentModified = true;
            }          
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateView()
        {
            if (m_SectionMgr.CurrentSection != null)
            {
                if (m_SectionMgr.CurrentSection.RtfData != null)
                {
                    this.Rtf = m_SectionMgr.CurrentSection.RtfData;
                    this.Visible = true;
                    this.Select(0,0);
                    this.ScrollToCaret();
                }
            }
            else
            {
                this.Visible = false;
            }

            Console.Write("RichTextBoxEx Update\n");
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetFontFamily(string family)
        {
           Font currentFont = this.SelectionFont;

            if (currentFont != null)
            {
                this.SelectionFont = new Font(family, currentFont.Size, currentFont.Style );
            }
            else
            {
                this.SelectionFont = new Font( family, this.Font.Size,this.Font.Style );            
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// 
        public static Font ReduceFontSize(System.Drawing.Font currentFont)
        {
            double size = (currentFont.Size / 1.2);   
   
            if(size <= 8.5)
            {
                size = 8.5;
            }      

            return new Font(currentFont.FontFamily, (int)size, currentFont.Style);
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static Font IncreaseFontSize(System.Drawing.Font currentFont)
        {
            double size = currentFont.Size * 1.2;  
            return new Font(currentFont.FontFamily, (int)size, currentFont.Style);
        } 

          /// <summary>
        /// 
        /// </summary>
        /// 
        public static Font MakeTextItalic(System.Drawing.Font currentFont)
        {  
            FontStyle newFontStyle;

            if (currentFont.Italic == false)
            {
                newFontStyle = currentFont.Style | FontStyle.Italic;
            }
            else
            {
                newFontStyle = currentFont.Style ^ FontStyle.Italic;
            }

           return new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }       


        /// <summary>
        /// 
        /// </summary>
        /// 
        public static Font MakeTextBold(System.Drawing.Font currentFont)
        {
            FontStyle newFontStyle;

            if (currentFont.Bold == false)
            {
                newFontStyle = currentFont.Style | FontStyle.Bold;
            }
            else
            {
                newFontStyle = currentFont.Style ^ FontStyle.Bold;
            }

            return new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        } 
        
    }
}
