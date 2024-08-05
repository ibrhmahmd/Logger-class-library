# ILogger Library

The `ILogger` library provides a flexible logging framework that adheres to the SOLID principles. It includes implementations for logging messages to text files and Excel sheets.

## Classes

### Logger (Abstract Class)
This is the base abstract class for all loggers. It defines the common interface that all concrete logger classes must implement.

**Properties:**
- `string Path`: The file path where logs will be stored.

**Methods:**
- `abstract void log(string msg)`: Method to log a message.

### TextFileLogger (Concrete Class)
This class provides an implementation of the `Logger` abstract class to log messages to a text file.

**Constructor:**
- `TextFileLogger(string fileName)`: Initializes a new instance of the `TextFileLogger` class with the specified file name.

**Methods:**
- `override void log(string msg)`: Logs a message to the specified text file.

### ExcelFileLogger (Concrete Class)
This class provides an implementation of the `Logger` abstract class to log messages to an Excel file using `Microsoft.Office.Interop.Excel`.

**Constructor:**
- `ExcelFileLogger(string fileName)`: Initializes a new instance of the `ExcelFileLogger` class with the specified file name.

**Methods:**
- `override void log(string msg)`: Logs a message to the specified Excel file.

## Usage

To use the `ILogger` library, create an instance of either the `TextFileLogger` or `ExcelFileLogger` class and call the `log` method with the message you want to log.
