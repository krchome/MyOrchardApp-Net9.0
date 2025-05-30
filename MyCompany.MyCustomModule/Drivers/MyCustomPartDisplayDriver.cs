using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using MyCompany.MyCustomModule.Models; // Your part's namespace

namespace MyCompany.MyCustomModule.Drivers
{
    public class MyCustomPartDisplayDriver : ContentPartDisplayDriver<MyCustomPart>
    {
        // This is called when displaying the part on the frontend
        public override IDisplayResult Display(MyCustomPart part, BuildPartDisplayContext context)
        {
            return Initialize<MyCustomPart>(GetDisplayShapeType(context), model =>
            {
                model.CustomData = part.CustomData;
                model.Importance = part.Importance;
            })
            .Location("Detail", "Content:10") // Position in Detail view
            .Location("Summary", "Content:10"); // Position in Summary view
        }

        // This is called when rendering the editor for the part in the admin UI
        public override IDisplayResult Edit(MyCustomPart part, BuildPartEditorContext context)
        {
            return Initialize<MyCustomPart>(GetEditorShapeType(context), model =>
            {
                model.CustomData = part.CustomData;
                model.Importance = part.Importance;
                // You can also pass other necessary data to the view model/shape here
            });
        }

        // This is called when the content item (with your part) is being saved from the editor
        // ***** CORRECTED UpdateAsync METHOD *****
        public override async Task<IDisplayResult> UpdateAsync(MyCustomPart part, UpdatePartEditorContext context) // [cite: 64]
        {
            // Access the IUpdateModel via context.Updater
            await context.Updater.TryUpdateModelAsync(part, Prefix, p => p.CustomData, p => p.Importance);

            // Optional: Add custom validation using context.Updater.ModelState
            // For example:
            // if (part.Importance.HasValue && part.Importance < 0)
            // {
            //     context.Updater.ModelState.AddModelError(nameof(part.Importance), "Importance cannot be negative.");
            // }

            // To re-render the editor, we call our Edit method.
            // The Edit method expects a BuildPartEditorContext.
            // UpdatePartEditorContext inherits from BuildPartEditorContext, so it can be passed directly.
            return Edit(part, context);
        }
    }
}