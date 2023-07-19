using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
        public void ConfigureServices(IServiceCollection services)
        {
            object MyConfig = null;
            // ...
            if (MyConfig.UseMicroServices)
                services.AddScoped<IAdminFacade, MicroServiceAdminFacade>();
            else
                services.AddScoped<IAdminFacade, AdminFacade>();
    }
}
