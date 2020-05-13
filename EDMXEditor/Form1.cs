using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EDMXEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEDMX_Click(object sender, EventArgs e)
        {
            var r = openFileDialog1.ShowDialog();
            if (r == DialogResult.Cancel)
                return;
            var f = openFileDialog1.FileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(f);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("edmx", textBoxEdmxNameSpace.Text);

            // get a list of nodes - in this case, I'm selecting all <AID> nodes under
            // the <GroupAIDs> node - change to suit your needs
            XmlNodeList a = doc.SelectNodes("//edmx:Edmx/edmx:Runtime/edmx:ConceptualModels", nsmgr);
            XmlNodeList aNodes = a[0].ChildNodes[0].ChildNodes;
            // loop through all AID nodes
            ConceptualModelsPostfix(aNodes);


            XmlNodeList b = doc.SelectNodes("//edmx:Edmx/edmx:Runtime/edmx:Mappings", nsmgr);
            XmlNodeList bNodes = b[0].ChildNodes[0].ChildNodes[0].ChildNodes;
            MappingsPostfix(bNodes);

            doc.Save(f);
            MessageBox.Show("Finish");
        }

        void MappingsPostfix(XmlNodeList bNodes)
        {
            foreach (XmlNode bNode in bNodes)
            {
                if(bNode.Name== "EntitySetMapping")
                {
                    XmlAttribute Name = bNode.Attributes["Name"];
                    Name.Value = Name.Value + textBoxEdmx.Text;

                    foreach (XmlNode EntityTypeMapping in bNode.ChildNodes)
                    {
                        if (EntityTypeMapping.Name == "EntityTypeMapping")
                        {
                            XmlAttribute TypeName = EntityTypeMapping.Attributes["TypeName"];
                            TypeName.Value = TypeName.Value + textBoxEdmx.Text;
                        }
                    }
                }
                else if (bNode.Name== "FunctionImportMapping")
                {
                    XmlAttribute FunctionImportName = bNode.Attributes["FunctionImportName"];
                    FunctionImportName.Value = FunctionImportName.Value + textBoxEdmx.Text;                      
                            
                    if (bNode.ChildNodes.Count > 0)
                    {
                        foreach (XmlNode ComplexTypeMapping in bNode.ChildNodes[0].ChildNodes)
                        {
                            XmlAttribute TypeName = ComplexTypeMapping.Attributes["TypeName"];
                            TypeName.Value = TypeName.Value + textBoxEdmx.Text;
                        }
                    }          
                }
            }
        }

        void ConceptualModelsPostfix(XmlNodeList aNodes)
        {
            foreach (XmlNode aNode in aNodes)
            {
                if (aNode.Name == "EntityType" || aNode.Name == "Association" || aNode.Name == "ComplexType")
                {
                    XmlAttribute idAttribute = aNode.Attributes["Name"];
                    idAttribute.Value = idAttribute.Value + textBoxEdmx.Text;
                    foreach (XmlNode End in aNode.ChildNodes)
                    {
                        if (End.Name == "NavigationProperty")
                        {
                            XmlAttribute Relationship = End.Attributes["Relationship"];
                            Relationship.Value = Relationship.Value + textBoxEdmx.Text;
                        }
                    }
                }
                if (aNode.Name == "Association")
                {
                    foreach (XmlNode End in aNode.ChildNodes)
                    {
                        if (End.Name == "End")
                        {
                            XmlAttribute tType = End.Attributes["Type"];
                            tType.Value = tType.Value + textBoxEdmx.Text;
                        }
                    }
                }

                if (aNode.Name == "EntityContainer")
                {
                    foreach (XmlNode End in aNode.ChildNodes)
                    {
                        if (End.Name == "EntitySet")
                        {
                            XmlAttribute EntityType = End.Attributes["EntityType"];
                            EntityType.Value = EntityType.Value + textBoxEdmx.Text;

                            XmlAttribute Name = End.Attributes["Name"];
                            Name.Value = Name.Value + textBoxEdmx.Text;

                        }
                        else if (End.Name == "AssociationSet")
                        {
                            XmlAttribute Name = End.Attributes["Name"];
                            Name.Value = Name.Value + textBoxEdmx.Text;

                            XmlAttribute Association = End.Attributes["Association"];
                            Association.Value = Association.Value + textBoxEdmx.Text;                            

                            foreach (XmlNode e in End.ChildNodes)
                            {
                                XmlAttribute EntitySet = e.Attributes["EntitySet"];
                                EntitySet.Value = EntitySet.Value + textBoxEdmx.Text;                                
                            }
                        }
                        else if(End.Name== "FunctionImport")
                        {
                            XmlAttribute Name = End.Attributes["Name"];
                            Name.Value = Name.Value + textBoxEdmx.Text;

                            XmlAttribute ReturnType = End.Attributes["ReturnType"];
                            if (ReturnType != null)
                            {
                                if (ReturnType.Value.Length > "Collection(Double)".Length+5)
                                {
                                    ReturnType.Value = ReturnType.Value.Replace(")", textBoxEdmx.Text+")");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            var r=openFileDialog1.ShowDialog();
            if (r == DialogResult.Cancel)
                return;
            var f = openFileDialog1.FileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(f);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("edmx", textBoxEdmxNameSpace.Text);

            // get a list of nodes - in this case, I'm selecting all <AID> nodes under
            // the <GroupAIDs> node - change to suit your needs
            XmlNodeList a = doc.SelectNodes("//edmx:Edmx/edmx:Designer/edmx:Diagrams", nsmgr);
            XmlNodeList Diagram = a[0].ChildNodes[0].ChildNodes;
            foreach (XmlNode aNode in Diagram)
            {
                if(aNode.Name== "EntityTypeShape")
                {
                    XmlAttribute EntityType = aNode.Attributes["EntityType"];
                    EntityType.Value = EntityType.Value + textBoxEdmx.Text;
                    
                }
                else if (aNode.Name == "AssociationConnector")
                {
                    XmlAttribute Association = aNode.Attributes["Association"];
                    Association.Value = Association.Value + textBoxEdmx.Text;                    
                }
            }

            doc.Save(f);
            MessageBox.Show("Finish");
        }
    }
}
