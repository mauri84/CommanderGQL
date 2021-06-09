using System.Linq;
using System;
using CommanderGQL.Models;
using HotChocolate.Types;
using HotChocolate;
using CommanderGQL.Data;

namespace CommanderGQL.GraphQL.Platforms {
  public class PlatformType : ObjectType<Platform> {
    protected override void Configure (IObjectTypeDescriptor<Platform> descriptor) {

      descriptor.Description("Represents any Software or Service that has a Command line Interface.");

      descriptor
        .Field(f => f.LicenseKey).Ignore();

      descriptor
        .Field(f => f.Commands)
        .ResolveWith<Resolvers>(r => r.GetCommands(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("This is the list of availanble commands for this platform.");
    }

    private class Resolvers {
      public IQueryable<Command> GetCommands (Platform platform, [ScopedService] AppDbContext context) {
        return context.Commands.Where(p => p.PlatformId == platform.Id);
      }
    }
  }
}