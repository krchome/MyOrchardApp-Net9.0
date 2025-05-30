using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using MyCompany.MyCustomModule.Models;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using MyCompany.MyCustomModule.Drivers;
using OrchardCore.DisplayManagement.Handlers; // Your part's namespace

namespace MyCompany.MyCustomModule
{
    public class Startup : OrchardCore.Modules.StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // Register the Content Part
            services.AddContentPart<MyCustomPart>();

            // Register the Migration
            services.AddDataMigration<Migrations>();

            // Fix for CS0311: Use the correct interface for MyCustomPartDisplayDriver
            // **** ADD THIS LINE TO REGISTER YOUR DISPLAY DRIVER ****
            services.AddContentPartDisplayDriver<MyCustomPartDisplayDriver>();

            
        }
    }
}
