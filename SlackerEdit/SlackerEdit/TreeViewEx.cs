using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SlackerEdit
{
    public partial class TreeNodeEx : System.Windows.Forms.TreeNode
    {
        public Section m_Section;
       
        /// <summary>
        /// 
        /// </summary>
        public TreeNodeEx(ref Section section)
        {
            if (section != null)
            {
                section.OnDataChanged += UpdateView;
                m_Section = section;
                UpdateView();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateView()
        {
            this.Text = m_Section.Title;
            Console.Write(" TreeNodeEx Update\n");
        }
    }

    public partial class TreeViewEx : System.Windows.Forms.TreeView
    {
        SectionMgr m_SectionMgr = null;
        System.Windows.Forms.TreeNode m_RootNode = null;
        System.Windows.Forms.TreeNode m_EmptyNode = null;
              
        /// <summary>
        /// 
        /// </summary>
        public TreeViewEx(SectionMgr sectionMgr)
        {
            sectionMgr.OnDataChanged += UpdateView;
            sectionMgr.OnAddSection += AddNode;
            sectionMgr.OnDeleteSection += DeleteNode;
            sectionMgr.OnResetAll += ResetAll;            

            m_SectionMgr = sectionMgr;

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "m_TreeView";
            this.Size = new System.Drawing.Size(260, 417);
            this.TabIndex = 0;

            this.FullRowSelect = true;
            this.HideSelection = false;
            this.LabelEdit = true;


	        m_RootNode = new System.Windows.Forms.TreeNode("Sections");
            this.Nodes.Add(m_RootNode);
                   
            AddEmptyNode();

            this.ExpandAll();
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;

           
            this.ContextMenu = new ContextMenu();
            MenuItem addSectionMenuItem = new MenuItem("&Add Section");
            MenuItem deleteSectionMenuItem = new MenuItem("&Delete Section");
            MenuItem renameSectionMenuItem = new MenuItem("&Rename Section");

            addSectionMenuItem.Click += new System.EventHandler(this.OnAddSectionMenuItem);
            deleteSectionMenuItem.Click += new System.EventHandler(this.OnDeleteSectionMenuItem);
            renameSectionMenuItem.Click += new System.EventHandler(this.OnRenameSectionMenuItem);

            this.ContextMenu.MenuItems.Add(addSectionMenuItem);
            this.ContextMenu.MenuItems.Add(deleteSectionMenuItem);
            this.ContextMenu.MenuItems.Add(renameSectionMenuItem);
            this.AfterSelect += new TreeViewEventHandler(OnAfterSelect);
            this.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.OnBeforeLabelEdit);
            this.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.OnAfterLabelEdit);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);

            this.AllowDrop = true;

            this.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnItemDrag);          
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
                
        }

        private void OnItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            pt = this.PointToClient(pt);
            TreeNode destinationNode = this.GetNodeAt(pt);
            if (destinationNode != null)
            {
                TreeNodeEx node = (TreeNodeEx)this.SelectedNode;
                TreeNodeEx clonedNode = node;             
                node.Remove();    
                m_RootNode.Nodes.Insert(destinationNode.Index, clonedNode);

                this.SelectedNode = clonedNode;    
               
                UpdateIndexes();
            }    
        }

        private void UpdateIndexes()
        {
            int currentIndex = 0;

            if (m_RootNode.FirstNode != m_EmptyNode)
            {
                foreach (TreeNodeEx node in m_RootNode.Nodes)
                {
                    node.m_Section.Index = currentIndex;                   
                    currentIndex++;
                }
            }
        }

        public bool GetNodeList( ref List<string> nodeList )
        {
            if (m_RootNode.Nodes.Count>1)
            {
                foreach (TreeNodeEx node in m_RootNode.Nodes)
                {
                    nodeList.Add(node.m_Section.Title);
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddEmptyNode()
        {
            if (m_EmptyNode == null)
            {
                m_EmptyNode = new System.Windows.Forms.TreeNode("None");
            }

            m_RootNode.Nodes.Add(m_EmptyNode);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddNode()
        {
            if (m_SectionMgr.CurrentSection != null)
            {
                if (m_RootNode.FirstNode == m_EmptyNode)
                {
                    m_EmptyNode.Remove();
                }

                Section currentSection = m_SectionMgr.CurrentSection;
                TreeNodeEx newNode = new TreeNodeEx(ref currentSection);
                m_RootNode.Nodes.Add(newNode);
                this.SelectedNode = newNode;
              
                currentSection.Index = this.SelectedNode.Index;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateView()
        {
            Console.Write("TreeViewEx Update\n");
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the section?", "Delete Section", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    m_SectionMgr.DeleteSection();
                }
            }
        }      
        
        /// <summary>
        /// 
        /// </summary>
        private void OnAfterSelect(Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {           
            TreeNode currentNode = this.SelectedNode;

            if (currentNode == m_RootNode && m_RootNode.Nodes.Count > 0 || currentNode == m_EmptyNode)
            {          
                m_SectionMgr.CurrentSection = null;          
                return;
            }
            else if (currentNode == m_RootNode && m_RootNode.Nodes.Count == 0)
            {
                return;
            }

            TreeNodeEx sectionNode = (TreeNodeEx)currentNode;
            m_SectionMgr.CurrentSection = sectionNode.m_Section;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node.IsEditing == true)
            {
                return;
            }

            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
           
            if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;          
          
            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                fore = SystemColors.HighlightText;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, SystemColors.Highlight);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.Default);               
            }
            else
            {              
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.Default);              
            }
        }

        public void ResetAll()
        {
            m_RootNode.Nodes.Clear();
            AddEmptyNode();
            this.SelectedNode = m_EmptyNode;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteNode()
        {
            TreeNode currentNode = this.SelectedNode;
            if (currentNode != m_RootNode && currentNode != m_EmptyNode)
            {
                currentNode.Remove();

                if (m_RootNode.Nodes.Count == 0)
                {
                    AddEmptyNode();
                    this.SelectedNode = m_EmptyNode;
                }

                UpdateIndexes();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RenameSection()
        {
            TreeNode currentNode = this.SelectedNode;
            if (currentNode != m_RootNode || currentNode == m_EmptyNode)
            {
                currentNode.BeginEdit();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnBeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode currentNode = this.SelectedNode;
            if (currentNode == m_RootNode || currentNode == m_EmptyNode)
            {
                e.CancelEdit = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.Node == null)
            {
                return;
            }

            if (e.Label == null)
            {
                return;
            }

               TreeNodeEx node = (TreeNodeEx)e.Node;
               string titleText = e.Label.Trim();
               if (titleText != "")
               {
                   if(m_SectionMgr.CurrentSection != null)
                   {
                       m_SectionMgr.CurrentSection.Title = titleText;
                   }
               }  
        }
             
        /// <summary>
        /// 
        /// </summary>
        private void OnAddSectionMenuItem(object sender, System.EventArgs e)
        {
            m_SectionMgr.AddSection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDeleteSectionMenuItem(object sender, System.EventArgs e)
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
        private void OnRenameSectionMenuItem(object sender, System.EventArgs e)
        {
            RenameSection();
        }    
                
    }
   
}
