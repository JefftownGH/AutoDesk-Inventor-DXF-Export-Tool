using System;
using System.Collections.Generic;
using System.Text;
using Inventor;
using System.Diagnostics;



namespace DesignValidationLibrary
{
    public class Part
    {
        public string Name { get; set; }
        public string material { get; set; }
        public PartDocument partDocument { get; set; }
        public List<string> errorList { get; set; }

        public Part()
        {
            errorList = new List<string>();
        }

        public void RetrieveDocumentUnits()
        {
            //this method retrieves the document units for each part and assigns them to the DocumentUnits string property

            //this is used later for design evaluation and cost analysis

            switch (partDocument.UnitsOfMeasure.LengthUnits)
            {
                case UnitsTypeEnum.kMillimeterLengthUnits:
                    {
                        break;
                    }

                case UnitsTypeEnum.kCentimeterLengthUnits:
                    {
                        break;
                    }
            }
        }

        public void PartCheck()
        {
            //add logic here for determining which checkboxes have been selected, most likely going to be passed as bools

            RetrieveDocumentUnits();
            MaterialCheck();
            SketchCheck();
            FeatureCheck();
        }
        private void MaterialCheck()
        {
            if(partDocument.ActiveMaterial.Name == "Nothing")
            {
                errorList.Add(String.Format("Material Set to {0}", partDocument.ActiveMaterial.Name));
            }
        }
        private void SketchCheck()
        {
            foreach (PlanarSketch oSketch in partDocument.ComponentDefinition.Sketches)
            {
                if(oSketch.ConstraintStatus.ToString() != "kFullyConstrainedConstraintStatus")
                {
                    errorList.Add(string.Format("{0} Is not fully constrained", oSketch.Name));
                }
            }
        }
        private void FeatureCheck()
        {
            int noSuppressedFeatures = 0;

            foreach(PartFeature oPartFeature in partDocument.ComponentDefinition.Features)
            {
                string healthStatus = oPartFeature.HealthStatus.ToString();

                switch(healthStatus)
                {
                    case "kSuppressedHealth":
                        noSuppressedFeatures += 1;
                        break;

                    case "kUnknownHealth":
                        errorList.Add(String.Format("{0} is unhealthy", oPartFeature.Name));
                        break;
                }
            }
            if (noSuppressedFeatures > 0)
            {
                errorList.Add(String.Format("{0} Suppressed Features", noSuppressedFeatures));
            }
        }
    }
}

