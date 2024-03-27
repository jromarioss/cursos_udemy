namespace _01APICatalogo.Logging;

public class CustomerLogger : ILogger
{
    readonly string loggerName;
    readonly CustomLoggerProviderConfiguration loggerConfig;

    public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
    {
        loggerName = name;
        loggerConfig = config;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == loggerConfig.LogLevel;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string mesagem = $"{logLevel.ToString()}: {eventId.Id} = {formatter(state, exception)}";
        EscreverTextoNoArquivo(mesagem);
    }

    private void EscreverTextoNoArquivo(string messagem)
    {
        string caminhoArquivo = @"d:\dados\aqui";

        using (StreamWriter streamWriter = new StreamWriter(caminhoArquivo, true))
        {
            try
            {
                streamWriter.WriteLine(messagem);
                streamWriter.Close();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
