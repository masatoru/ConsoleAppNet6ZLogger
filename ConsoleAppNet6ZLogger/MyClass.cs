using Microsoft.Extensions.Logging;
using ZLogger;
namespace ConsoleAppNet6ZLogger;

public class MyClass
{
    readonly ILogger<MyClass> logger;

    // get logger from DI.
    public MyClass(ILogger<MyClass> logger)
    {
        this.logger = logger;
    }

    public void Foo()
    {
        // log text.
        logger.ZLogDebug("foo{0} bar{1}", 10, 20);

        // log text with structure in Structured Logging.
        logger.ZLogDebugWithPayload(new { Foo = 10, Bar = 20 }, "foo{0} bar{1}", 50, 100);

        // error text.
        logger.ZLogError("foo{0} bar{1}", 100000, 2000000);
    }
}