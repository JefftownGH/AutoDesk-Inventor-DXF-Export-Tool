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
        CollectionMaterialProperties collectionMaterialProperties = CollectionMaterialProperties.CreateCollectionMaterialProperties();

        public MaterialProperties()
        {
            InitializeComponent();
            collectionMaterialProperties.ImportJsonFile();
            UpdateMaterialsCollection();
        }
        
        private void UpdateMaterialsCollection()
        {
            MaterialsCollection.Items.Clear();
            MaterialsCollection.DisplayMember = "materialName";
            collectionMaterialProperties.AlphabeticallySortMaterialProperties();

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

        #region FormButtons
        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            if (!InputValidation()) return;

            else
            {
                AddNewMaterialPropertyToCollection();
                UpdateMaterialsCollection();
                ClearTextBoxes();
            }
        }

        private void RemoveMaterialButton_Click(object sender, EventArgs e)
        {
            collectionMaterialProperties.RemoveMaterialProperty(SelectedItemMaterialsCollectionString());
            UpdateMaterialsCollection();
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

        public void AddNewMaterialPropertyToCollection()
        {
            string materialName = MaterialNameTextBox.Text;
            string materialDescription = MaterialDescriptionTextBox.Text;
            decimal costPerKilogram = Convert.ToDecimal(MaterialCostTextBox.Text);
            double maxSheetLength = Convert.ToDouble(MaxSheetLengthTextBox.Text);
            double maxSheetWidth = Convert.ToDouble(MaxSheetWidthTextBox.Text);
            double kFactor = Convert.ToDouble(KFactorTextBox.Text);

            collectionMaterialProperties.AddNewMaterialProperty(materialName, materialDescription, costPerKilogram, maxSheetLength, maxSheetWidth, kFactor);
        }

        private void ClearTextBoxes()
        {
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
