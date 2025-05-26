using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyCustomModule.Models
{
    public class MyCustomPart : ContentPart
    {
        // Example property
        public string? CustomData { get; set; }
        public int? Importance { get; set; }
    }
}
