using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using static ConsoleWeb.Classes.Helpers;

namespace ConsoleWeb
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app)
        {

            app.Run(context => 
                context.Response.WriteAsync($"Good {TimeOfDay()}"));

        }
    }
}
