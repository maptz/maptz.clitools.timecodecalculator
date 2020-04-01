using Maptz;
using Maptz.CliTools;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Maptz.CliTools.TimecodeCalculator.Tool
{

     public class CLIProgramRunner : ICliProgramRunner
    {
        /* #region Public Properties */
        public AppSettings AppSettings { get; }
        public IServiceProvider ServiceProvider { get; }
        /* #endregion Public Properties */
        /* #region Public Constructors */
        public CLIProgramRunner(IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
        {
            this.AppSettings = appSettings.Value;
            this.ServiceProvider = serviceProvider;
        }
        /* #endregion Public Constructors */
        /* #region Public Methods */
        public async Task RunAsync(string[] args)
        {
            await Task.Run(() =>
            {
                CommandLineApplication cla = new CommandLineApplication(throwOnUnexpectedArg: false);
                cla.HelpOption("-?|-h|--help");

                /* #region get */
                cla.Command("get", config =>
                                {
                                    //var inputOption = config.Option("-i|--input <inputFilePath>", "The project file", CommandOptionType.SingleValue);
                                    config.OnExecute(() =>
                                    {
                                        //var inputFilePath = inputOption.HasValue() ? inputOption.Value() : null;
                                        return 0;
                                    });

                                });
                /* #endregion*/

                /* #region Default */
                //Just show the help text.
                cla.OnExecute(() =>
                {
                    cla.ShowHelp();
                    return 0;

                });
                /* #endregion*/
                cla.Execute(args);
            });
        }
        /* #endregion Public Methods */
    }
}