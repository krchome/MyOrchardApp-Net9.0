using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using MyCompany.MyCustomModule.Models; // Your part's namespace
using OrchardCore.Autoroute.Models;
namespace MyCompany.MyCustomModule
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        // This method is executed when the module is first enabled.
        public async Task<int> CreateAsync()
        {
            // Define our custom part
            // The AlterPartDefinitionAsync method can be awaited.
            await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(MyCustomPart), part => part
                .Attachable() // Makes the part available to be attached to content types in the UI
                .WithDescription("A custom part to store additional information.")
            // You can also define fields directly on the part here if needed,
            // though often fields are added when attaching the part to a type.
            );

            // Example: Attach the part to an existing or new Content Type (e.g., "Article")
            // If you want to create a new Content Type and attach your part:
            await _contentDefinitionManager.AlterTypeDefinitionAsync("MyCustomContentType", type => type
                .Creatable()
                .Listable()
                .WithPart("TitlePart", part => part.WithPosition("0")) // Common part for a title
                .WithPart(nameof(MyCustomPart), part => part.WithPosition("1")) // Your custom part
                .WithPart("AutoroutePart", part => part // For generating URLs
                    .WithSettings(new AutoroutePartSettings
                    {
                        AllowCustomPath = true,
                        Pattern = "{{ ContentItem.DisplayText | slugify }}"
                    })
                    .WithPosition("2")
                )
            );

            // If you want to attach it to an existing type like "Article":
            /*
            await _contentDefinitionManager.AlterTypeDefinitionAsync("Article", type => type
                .WithPart(nameof(MyCustomPart), part => part
                    .WithDisplayName("My Custom Data") // How the part appears in the type editor
                    .WithPosition("5") // Adjust position as needed
                )
            );
            */

            return 1; // This is the first version of the migration.
        }

        // Example of an update migration (if you make changes later)
        // public async Task<int> UpdateFrom1Async()
        // {
        //    // Make changes to the part or type definitions
        //    await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(MyCustomPart), part => part
        //        .WithField("NewField", field => field
        //            .OfType("TextField") // Example: Adding a TextField
        //            .WithDisplayName("A New Field")
        //        )
        //    );
        //    return 2;
        // }
    }
}