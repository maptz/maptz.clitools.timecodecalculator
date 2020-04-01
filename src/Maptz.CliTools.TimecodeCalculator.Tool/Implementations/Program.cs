//using Maptz.CliTools.TimecodeCalculator.Tool.Engine
using Maptz.CliTools;
using Microsoft.Extensions.DependencyInjection;
using Maptz.CliTools;
using Microsoft.Extensions.Logging;

namespace Maptz.CliTools.TimecodeCalculator.Tool
{

  class Program : CliProgramBase<AppSettings>
    {
        public static void Main(string[] args) 
        {
            new Program(args);
        }

        public Program(string[] args) : base(args)
        {

        }

        protected override void AddServices(IServiceCollection services)
        {
            base.AddServices(services);
            services.AddTransient<ICliProgramRunner, CLIProgramRunner>();

            services.AddLogging(loggingBuilder => loggingBuilder.AddConfiguration(Configuration.GetSection("Logging")).AddConsole().AddDebug());
        }
    }

}


