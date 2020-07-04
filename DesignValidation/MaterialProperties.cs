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

        private void ImportJsonFile()
        {
            string filePath = collectionMaterialProperties.GenerateJsonFilePath();

            if (!FileHandling.CheckIfFileExists(filePath))
            {
                //if a json file cannot be found in the resources directory, a standard template is created then saved to create a json file
                MaterialProperty defaultMaterial = new MaterialProperty();

                //move to defaultMaterial method!!! to add the default material profile = cleans up this code
                defaultMaterial.materialName = "Default";
                defaultMaterial.materialDescription = "The standard material profile";
                defaultMaterial.costPerKilogram = 1.00M;
                defaultMaterial.maxSheetLength = 3000;
                defaultMaterial.maxSheetWidth = 1500;
                defaultMaterial.kFactor = 0.5;

                collectionMaterialProperties.materialProperties.Add(defaultMaterial);

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
            
            foreach(MaterialProperty materialProperty in collectionMaterialProperties.materialProperties)
            {
                MaterialsCollection.Items.Add(materialProperty);
            }
        }

        private MaterialProperty SelectedItemMaterialsCollection()
        {
            MaterialProperty selectedItem = (MaterialProperty)MaterialsCollection.SelectedItem;

            if (selectedItem == null)
                MessageBox.Show("Please Select one material property");

            return selectedItem;
        }

        private void RemoveMaterialProperty(MaterialProperty materialProperty)
        {
            collectionMaterialProperties.materialProperties.Remove(materialProperty);

            FileHandling.SaveStringToFile(collectionMaterialProperties.SerializeJson(), collectionMaterialProperties.GenerateJsonFilePath(), true);

            UpdateMaterialsCollection();
        }

        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            if (!InputValidation()) return;

            else
                CreateNewMaterialProperty();
        }

        private void RemoveMaterialButton_Click(object sender, EventArgs e)
        {
            MaterialProperty materialPropertyToRemove  = SelectedItemMaterialsCollection();

            RemoveMaterialProperty(materialPropertyToRemove);
        }

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
            }

            return true;
        }

        private void CreateNewMaterialProperty()
        {
            try
            {
                MaterialProperty materialProperty = new MaterialProperty();

                materialProperty.materialName = MaterialNameTextBox.Text;
                materialProperty.materialDescription = MaterialNameTextBox.Text;
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
    }
}
