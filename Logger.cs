
namespace ILogger
{
    public abstract class Logger
    {

        public string Path { get; set; }

        public abstract void log(string msg);

    }
}