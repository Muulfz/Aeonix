# Changelog
## 1.0.2 (December 27th, 2017)
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
