SELECT *
FROM [CommandsDB].[dbo].[Platforms]
SELECT *
FROM [CommandsDB].[dbo].[Commands]

-- INSERT INTO Platforms
--   ([Name])
-- VALUES
--   ('.NET 5')
-- INSERT INTO Platforms
--   ([Name])
-- VALUES
--   ('Docker')
-- INSERT INTO Platforms
--   ([Name],[LicenseKey])
-- VALUES
--   ('Windows', '78979879879870987')

INSERT INTO Commands
  ([HowTo],[CommandLine],[PlatformId])
VALUES
  ('Build a project', 'dotnet build', 1)
INSERT INTO Commands
  ([HowTo],[CommandLine],[PlatformId])
VALUES
  ('Run a project', 'dotnet run', 1)
INSERT INTO Commands
  ([HowTo],[CommandLine],[PlatformId])
VALUES
  ('Start a docker compose file', 'docker-compose up -d', 2)
INSERT INTO Commands
  ([HowTo],[CommandLine],[PlatformId])
VALUES
  ('Stop a docker compose file', 'docker-compose stop', 2)
