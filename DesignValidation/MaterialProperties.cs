using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialPropertiesLibrary;
using ProgramUtilities;


namespace DesignValidation
{
    public partial class MaterialProperties : Form
    {
        CollectionMaterialProperties collectionMaterialProperties = new CollectionMaterialProperties();

        public MaterialProperties()
        {
            InitializeComponent();
            ImportJsonFile();
        }
        //prototype code..badly in need of a refactor and moving logic into classes...
        
        //all this could be move to collectionMaterialProperties class
        private void ImportJsonFile()
        {
            string filePath = collectionMaterialProperties.GenerateJsonFilePath();

            if (!FileHandling.CheckIfFilesExists(filePath))
            {
                collectionMaterialProperties.AddDefaultMaterialProperty();

                FileHandling.SaveStringToFile(collectionMaterialProperties.SerializeJson(), filePath,true);
            }
            else
            {
                collectionMaterialProperties.DeserialiseJson(filePath);
            }

            UpdateMaterialsCollection();
        }

        private void UpdateMaterialsCollection()
        {
            MaterialsCollection.Items.Clear();
            MaterialsCollection.DisplayMember = "materialName";

            collectionMaterialProperties.materialProperties.Sort((x, y) => string.Compare(x.materialName, y.materialName));

            foreach(MaterialProperty materialProperty in collectionMaterialProperties.materialProperties)
                MaterialsCollection.Items.Add(materialProperty);
        }

        private string SelectedItemMaterialsCollectionString()
        {
            MaterialProperty selectedItem = (MaterialProperty)MaterialsCollection.SelectedItem;

            if (selectedItem == null)
                MessageBox.Show("Please Select one material property");

            return selectedItem.materialName;
        }

        private MaterialProperty SelectedItemMaterialsCollectionObject()
        {
            MaterialProperty selectedItem = (MaterialProperty)MaterialsCollection.SelectedItem;

            if (selectedItem == null)
                MessageBox.Show("Please Select one material property");

            return selectedItem;
        }

        private void RemoveMaterialProperty(string materialPropertyName)
        {
            if (materialPropertyName == "Default")
            {
                MessageBox.Show("Cannot delete the Default material property");
                return;
            }
            collectionMaterialProperties.materialProperties.RemoveAll(x => x.materialName == materialPropertyName);

            FileHandling.SaveStringToFile(collectionMaterialProperties.SerializeJson(), collectionMaterialProperties.GenerateJsonFilePath(), true);

            UpdateMaterialsCollection();
        }

        #region FormButtons

        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            if (!InputValidation()) return;

            else
                CreateNewMaterialProperty();
        }

        private void RemoveMaterialButton_Click(object sender, EventArgs e)
        {
            string materialPropertyToRemove  = SelectedItemMaterialsCollectionString();

            RemoveMaterialProperty(materialPropertyToRemove);
        }

        private void EditMaterialButton_Click(object sender, EventArgs e)
        {
            MaterialProperty materialPropertyToEdit = SelectedItemMaterialsCollectionObject();

            MaterialNameTextBox.Text = materialPropertyToEdit.materialName;
            MaterialDescriptionTextBox.Text = materialPropertyToEdit.materialDescription;
            MaterialCostTextBox.Text = materialPropertyToEdit.costPerKilogram.ToString();
            MaxSheetLengthTextBox.Text = materialPropertyToEdit.maxSheetLength.ToString();
            MaxSheetWidthTextBox.Text = materialPropertyToEdit.maxSheetWidth.ToString();
            KFactorTextBox.Text = materialPropertyToEdit.kFactor.ToString();
        }

        #endregion

        private bool InputValidation()
        {
            #region Notes

            //This method validates the inputs, but does not assign the values to variables

            #endregion

            if(MaterialNameTextBox.Text == "" || MaterialNameTextBox.Text.Length > 20)
            {
                MessageBox.Show("Input value error for Material Name");
                return false;
            }

            if(MaterialDescriptionTextBox.Text == "" || MaterialNameTextBox.Text.Length > 200)
            {
                MessageBox.Show("Input value error for Material Description");
                return false;
            }

            if(decimal.TryParse(MaterialCostTextBox.Text,out decimal MaterialCost) != true)
            {
                MessageBox.Show("Input value error for Material Cost");
                return false;
            }

            if(double.TryParse(MaxSheetWidthTextBox.Text,out double maxSheetWidth) != true)
            {
                MessageBox.Show("Input value error for Max Sheet Width");
                return false;
            }
            else if(maxSheetWidth <100 || maxSheetWidth > 10000)
            {
                MessageBox.Show("Input is outside permitted range for Max sheet width");
                return false;
            }

            if(double.TryParse(MaxSheetLengthTextBox.Text,out double maxSheetLength) != true)
            {
                MessageBox.Show("Input value error for Max Sheet Length");
                return false;
            }
            else if(maxSheetLength < 100 || maxSheetLength > 10000)
            {
                MessageBox.Show("Input is outside permitted range for Max Sheet Length");
                return false;
            }

            if(double.TryParse(KFactorTextBox.Text,out double kFactor)!= true)
            {
                MessageBox.Show("Input value error for K factor");
                return false;
            }
            else if (kFactor <= 0 || kFactor >= 1)
            {
                MessageBox.Show("Input value error for K factor");
                return false;
            }

            return true;
        }

        private void CreateNewMaterialProperty()
        {
            //if the same name is already being used, checks to see if you should overwrite the material properties or not
            string inputMaterialPropertyName = MaterialNameTextBox.Text;

            //improve to fix glitch with trying to modify the default material profile
            if (CheckIfMaterialNameIsInUse(inputMaterialPropertyName))
            {
                DialogResult materialNameDialogueResult = MessageBox.Show("This material property already exists, do you want to overwrite it?",
                    "Add Material Property", MessageBoxButtons.YesNo);

                switch (materialNameDialogueResult)
                {
                    case DialogResult.No:
                        return;

                    case DialogResult.Yes:
                        RemoveMaterialProperty(inputMaterialPropertyName);
                        break;
                }
            }

            try
            {
                MaterialProperty materialProperty = new MaterialProperty();

                materialProperty.materialName = inputMaterialPropertyName;
                materialProperty.materialDescription = MaterialDescriptionTextBox.Text;
                materialProperty.costPerKilogram = Convert.ToDecimal(MaterialCostTextBox.Text);
                materialProperty.maxSheetLength = Convert.ToDouble(MaxSheetLengthTextBox.Text);
                materialProperty.maxSheetWidth = Convert.ToDouble(MaxSheetWidthTextBox.Text);
                materialProperty.kFactor = Convert.ToDouble(KFactorTextBox.Text);

                collectionMaterialProperties.materialProperties.Add(materialProperty);

                #region Notes

                //Serialise the collectionMaterialProperties.materialProperties List<MaterialProperty> to json
                //collectionMaterialProperties.SerializeJson();

                //retrive the filepath were the json is saved
                //collectionMaterialProperties.GenerateJsonFilePath();

                //Then the json string is saved to file :=)

                #endregion

                FileHandling.SaveStringToFile(collectionMaterialProperties.SerializeJson(), collectionMaterialProperties.GenerateJsonFilePath(), true);

                UpdateMaterialsCollection();
                ClearTextBoxes();
            }
            catch
            {
                MessageBox.Show("An error was encountered adding the material to the library");
            }            
        }

        private void ClearTextBoxes()
        {
            //clears the input values of all the textboxes in the form

            Action<Control.ControlCollection> clearInputValues = null;

            clearInputValues = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        clearInputValues(control.Controls);
            };

            clearInputValues(Controls);
        }

        private bool CheckIfMaterialNameIsInUse(string materialNameToCheck)
        {
            bool nameAlreadyInUse = collectionMaterialProperties.materialProperties.Any(name => name.materialName == materialNameToCheck);
            return nameAlreadyInUse;
        }
    }
}
