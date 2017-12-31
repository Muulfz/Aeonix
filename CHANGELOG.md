# Changelog
## 1.0.3 (December 31st, 2017)
- Updated `.gitignore`
- Added methods for logging to client/server (fixes #2)
  - Changed over all internal logging to use these new methods
- Added a `Color` utility class, provides base colors for actions, errors, success messages and warnings (fixes #17)
- Renamed `Util` > `Util.Helper` to prevent naming collisions
- Removed an unneccesary log message

### 1.0.2 (December 27th, 2017)
- Moved all document files into their own folder (fixes #16)
- Fixed command usage not stripping spaces from command names (fixes #15)
- Added a `Util` class to hold general helper methods
- Added `PULL_REQUEST_TEMPLATE.md` (fixes #10)

### 1.0.1 (December 23rd, 2017)
- Moved all classes into their proper namespace, `Aeonix`
- Renamed 2 classes to prevent namespacing issues:
  - `Command` > `CommandBase`
  - `CommandHandler` > `CommandHandlerBase`
- Moved `CommandHandlerBase` constructor(s) into a method called `Init`
- [Code Cleanup](https://github.com/TakeTenGaming/Aeonix/issues/1)

### 1.0.0 (December 22nd, 2017)
- Initial Framework release
