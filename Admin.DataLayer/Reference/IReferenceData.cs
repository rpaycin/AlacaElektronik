using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IReferenceData
    {
        List<Referans> GetReferences();

        void UpdateReference(Referans reference);

        void SaveReference(Referans reference);

        void DeleteReference(int referenceId);
        List<Referans> GetSliderReferences();
    }
}
