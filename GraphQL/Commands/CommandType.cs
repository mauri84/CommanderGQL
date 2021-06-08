using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands {
  public class CommandType : ObjectType<Command> {

    protected override void Configure (IObjectTypeDescriptor<Command> descriptor) {
      descriptor.Description("Represents any executable command.");

      descriptor
        .Field(f => f.Platform)
        .ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("This is the platform to which the command belongs.");
    }

    private class Resolvers {
      public Platform GetPlatform (Command command, [ScopedService] AppDbContext context) {
        return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
      }
    }
  }
}