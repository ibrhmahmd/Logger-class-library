# ILogger Library

The `ILogger` library provides a flexible logging framework with implementations for logging messages to text files and Excel sheets.

## Classes

### Logger (Abstract)
- **Properties:** `string Path`
- **Methods:** `abstract void log(string msg)`

### TextFileLogger
Logs messages to a text file.

**Usage:**
```csharp
Logger textLogger = new TextFileLogger("log.txt");
textLogger.log("This is a log message in text file.");
