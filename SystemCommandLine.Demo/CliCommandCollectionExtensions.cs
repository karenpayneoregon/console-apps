// <copyright file="CliCommandCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.Linq;
    using SystemCommandLine.Demo;

    /// <summary>
    /// Contains the collection extensions for adding the CLI commands.
    /// </summary>
    public static class CliCommandCollectionExtensions
    {
        /// <summary>
        /// Adds the CLI commands to the DI container. These are resolved when the commands are registered with the
        /// <c>CommandLineBuilder</c>.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection, for chaining.</returns>
        /// <remarks>
        /// We are using convention to register the commands; essentially everything in the same namespace as the
        /// <see cref="DeployCommand"/> and that implements <c>Command</c> will be registered. If any commands are
        /// added in other namespaces, this method will need to be modified/extended to deal with that.
        /// </remarks>
        public static IServiceCollection AddCliCommands(this IServiceCollection services)
        {
            Type grabCommandType = typeof(GreetCommand);
            Type commandType = typeof(Command);

            IEnumerable<Type> commands = grabCommandType
                .Assembly
                .GetExportedTypes()
                .Where(x => x.Namespace == grabCommandType.Namespace && commandType.IsAssignableFrom(x));

            foreach (Type command in commands)
            {
                services.AddSingleton(commandType, command);
            }

            services.AddSingleton(sp =>
            {
                return
                   sp.GetRequiredService<IConfiguration>().GetSection("Greet").Get<GreetOptions>()
                   ?? throw new ArgumentException("Greeting configuration cannot be missing.");
            });

            return services;
        }
    }
}
