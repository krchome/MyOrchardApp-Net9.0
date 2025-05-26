using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using MyCompany.MyCustomModule.Models; // Your part's namespace

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

            // If you were to add drivers for display/editing:
            // services.AddContentPartDisplayDriver<MyCustomPartDisplayDriver>();
        }
    }
}