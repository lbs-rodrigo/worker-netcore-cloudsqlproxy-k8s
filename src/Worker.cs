namespace Example.Worker.Cloudsqlproxy
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _log;
        public readonly IHostApplicationLifetime _lifeTime;

        public Worker(
            ILogger<Worker> log,
            IHostApplicationLifetime lifeTime) 
        {
            _log = log;
            _lifeTime = lifeTime;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
             _log.LogInformation("Start Worker");
            await ExecuteAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(120 * 1000);
            await KillCloudSQLProxy();
            _lifeTime.StopApplication();

            _log.LogInformation("Stoped");
        }

        private async Task ExampleKillCloudSQLProxy()
        {
            try
            {
                string command = "pgrep";
                string argument = "cloud_sql_proxy";
                var searchPID = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = command,
                    Arguments = argument,
                    RedirectStandardOutput = true
                };
                var startSearch = Process.Start(searchPID);
                var sqlPID = await startSearch.StandardOutput.ReadToEndAsync();
                _log.LogInformation($"Info about process: {command} {argument} - output: {sqlPID}");

                command = "kill";
                argument = $"-s SIGTERM {int.Parse(sqlPID)}";

                var killPID = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = command,
                    Arguments = argument,
                    RedirectStandardOutput = true
                };
                var startKill = Process.Start(killPID);
                var sqlKill = await startKill.StandardOutput.ReadToEndAsync();
                _log.LogInformation($"Info about kill process: {command} {argument} - output: {sqlKill}");
            }
            catch(Exception ex) 
            { 
                _log.LogError($"Error: {ex}");
            }
        }
    }
}