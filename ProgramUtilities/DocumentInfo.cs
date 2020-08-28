using Inventor;

namespace ProgramUtilities
{
    public static class DocumentInfo
    {
        readonly static string sheetMetalCLSID = "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}";

        public static bool IsAssemblyDocument(DocumentTypeEnum activeDocumentType)
        {
            if (activeDocumentType == DocumentTypeEnum.kAssemblyDocumentObject)
                return true;

            else
                return false;
        }

        public static bool IsPartDocument(DocumentTypeEnum activeDocumentType)
        {
            if (activeDocumentType == DocumentTypeEnum.kPartDocumentObject)
                return true;

            else
                return false;
        }

        public static bool IsSheetMetalPart(string activeDocumentSubType)
        {
            if (activeDocumentSubType == sheetMetalCLSID)
                return true;

            else
                return false;
        }
    }
}
