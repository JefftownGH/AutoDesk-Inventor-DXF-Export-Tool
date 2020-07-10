using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;
using System.Diagnostics;
using DesignValidationLibrary;
using MaterialPropertiesLibrary;
using ProgramUtilities;

namespace DesignValidation
{
    public partial class DesignValidationForm : Form
    {
        //Creating an instance of the InventorConnection class
        public InventorConnection inventorConnection = new InventorConnection();

        //declaring a variable for the InventorConnection
        private Inventor.Application ThisApplication = null;

        private TopLevel topLevel = new TopLevel();
        private BindingSource errorList = new BindingSource();
        private List<Node> data = new List<Node>();
        private BrightIdeasSoftware.TreeListView treeListView;

        class Node
        {
            public string Name { get; set; }
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public List<Node> Children { get; set; }
            public Node(string name, string col1, string col2, string col3)
            {
                this.Name = name;
                this.Column1 = col1;
                this.Column2 = col2;
                this.Column3 = col3;
                this.Children = new List<Node>();
            }
        }

        public DesignValidationForm()
        {
            InitializeComponent();
            InventorConnection();
            AddTree();
            FillTree();
        }

        private void FillTree()
        {
            //Stops multiple columns being added to the table
            this.treeListView.Clear();

            this.treeListView.CanExpandGetter = x => (x as Node).Children.Count > 0;
            this.treeListView.ChildrenGetter = x => (x as Node).Children;

            var nameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            nameCol.AspectGetter = x => (x as Node).Name;

            var col1 = new BrightIdeasSoftware.OLVColumn("Column1", "Column1");
            col1.AspectGetter = x => (x as Node).Column1;

            var col2 = new BrightIdeasSoftware.OLVColumn("Column2", "Column2");
            col2.AspectGetter = x => (x as Node).Column2;

            var col3 = new BrightIdeasSoftware.OLVColumn("Column3", "Column3");
            col3.AspectGetter = x => (x as Node).Column3;

            this.treeListView.Columns.Add(nameCol);
            this.treeListView.Columns.Add(col1);
            this.treeListView.Columns.Add(col2);
            this.treeListView.Columns.Add(col3);

            this.treeListView.Roots = data;
        }

        private void BuildComponentList(List<Assembly> assembly)
        {
            foreach (Assembly asm in assembly)
            {
                Node asmNode = new Node(asm.Name, "-", "-", "-");
                data.Add(asmNode);

                foreach (Part part in asm.ComponentList)
                    asmNode.Children.Add(new Node(part.Name, "-", "-", "-"));
            }
        }

        private void AddTree()
        {
            treeListView = new BrightIdeasSoftware.TreeListView();

            treeListView.Location = new System.Drawing.Point(20, 100);
            treeListView.Size = new System.Drawing.Size(650, 325);
            treeListView.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            
            treeListView.UseAlternatingBackColors = true;
            treeListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(204, 229, 255);

            this.Controls.Add(treeListView);
        }

        private void InventorConnection()
        {
            ThisApplication = inventorConnection.CreateInventorConnection();

            if (ThisApplication == null)
                MessageBox.Show("Unable to establish a connection with Inventor");
        }

        private void DetermineDocumentType()
        {
            if (DocumentInfo.IsAssemblyDocument(ThisApplication.ActiveDocument.DocumentType))
            {
                AssemblyDocument AsmDoc = (AssemblyDocument)ThisApplication.ActiveDocument;
                topLevel.TraverseAssembly(AsmDoc, 0);
            }

            else if (DocumentInfo.IsPartDocument(ThisApplication.ActiveDocument.DocumentType))
            {
                MessageBox.Show("This is a part document, currently only assembly documents are supported");
            }
        }
        private void Import_Click(object sender, EventArgs e)
        {
            //refactor all of this code!!!

            DetermineDocumentType();
            UpdateProgressBar(true);
            DesignCheck();
            UpdateProgressBar(true);
            BuildComponentList(topLevel.AssemblyList);
            FillTree();
            
        }

        private void InspectComponent_Click(object sender, EventArgs e)
        {
            foreach(Node treeListViewNode in treeListView.SelectedObjects)
            {
                string selectedNode = treeListViewNode.Name;

                foreach (Assembly assembly in topLevel.AssemblyList)
                {
                    if(selectedNode == assembly.Name)
                    {
                        MessageBox.Show("Please select a component");
                    }

                    foreach (Part part in assembly.ComponentList)
                    {
                        if(selectedNode == part.Name)
                        {
                            InspectPartView(part);
                        }
                    }
                }
            }
        }

        private void TraverseAssembly(AssemblyDocument AsmDoc, int ParentID)
        {
            //this method is now redundant and has been moved to the TopLevel class
            int ID;
            if (topLevel.IDlist.Any())
                ID = topLevel.IDlist.Last() + 1;

            else
                ID = 1; 

            topLevel.IDlist.Add(ID);

            Assembly assembly = new Assembly { Name = AsmDoc.DisplayName, assemblyDocument = AsmDoc, ParentID = ParentID, ID = ID};

            topLevel.AssemblyList.Add(assembly);

            ComponentOccurrences Occurrences = AsmDoc.ComponentDefinition.Occurrences;

            topLevel.noOccurrences += Occurrences.Count;

            foreach (ComponentOccurrence oOcc in Occurrences)
            {
                UpdateProgressBar(false);

                if (oOcc.DefinitionDocumentType == DocumentTypeEnum.kPartDocumentObject)
                {
                    //Checks if standard part or sheetmetal part, the sheetmetal class is a child of the part base class
                    PartDocument PartDoc = oOcc.Definition.Document;

                    string sheetmetalCLSID = "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}";

                    if(PartDoc.SubType == sheetmetalCLSID)
                    {
                        SheetmetalPart sheetmetalPart = new SheetmetalPart() { Name = PartDoc.DisplayName, partDocument = PartDoc };

                        assembly.ComponentList.Add(sheetmetalPart);
                    }
                    else
                    {
                        Part part = new Part { Name = PartDoc.DisplayName, partDocument = PartDoc };

                        assembly.ComponentList.Add(part);
                    }
                }

                if(oOcc.DefinitionDocumentType == DocumentTypeEnum.kAssemblyDocumentObject)
                {
                    AssemblyDocument SubAsmDoc = oOcc.Definition.Document;

                    int parentID = assembly.ID;

                    TraverseAssembly(SubAsmDoc, parentID);
                }
            }
        }

        private void InspectPartView(Part part)
        {
            errorList.ResetBindings(false);
            errorList.DataSource = part.errorList;
            ComponentErrors.DataSource = errorList;
        }

        public void DesignCheck()
        {
            UpdateProgressBar(false);

            foreach(Assembly asm in topLevel.AssemblyList)
            {
                foreach(Part part in asm.ComponentList)
                {
                    part.PartCheck();

                    UpdateProgressBar(false);
                }

                IEnumerable<Part> sheetmetalPartList = asm.ComponentList.Where(p => p.GetType() == typeof(SheetmetalPart));

                foreach (SheetmetalPart sheetmetalPart in sheetmetalPartList)
                {
                    sheetmetalPart.FlatPatternArea();

                    UpdateProgressBar(false);
                }
            }
        }

        public void UpdateProgressBar(bool processComplete)
        {
            ProgressBar.Visible = true;
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = topLevel.noOccurrences;
            ProgressBar.Step = 1;
            ProgressBar.PerformStep();

            if(processComplete)
            {
                ProgressBar.Value = 0;
                ProgressBar.Visible = false;
            }
        }

        private void AddMaterial_Click(object sender, EventArgs e)
        {
            MaterialProperties materialProperties = new MaterialProperties();
            materialProperties.Show();
        }

    }
}
