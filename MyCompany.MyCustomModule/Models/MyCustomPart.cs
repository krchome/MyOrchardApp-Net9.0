using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace MyCompany.MyCustomModule.Models
{
    public class MyCustomPart : ContentPart
    {
        // Example property
        public string? CustomData { get; set; }
        public int? Importance { get; set; }
    }
}
