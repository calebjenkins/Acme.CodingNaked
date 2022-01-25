namespace SlightlyHarderLib
{
    public class BusinessCounter : IBusinessCounter
    {
        private int _counter;
        private IAppLogger _logger;
        // private IEnterpriseLogger _logger;

        // public BusinessCounter(IEnterpriseLogger logger)
        public BusinessCounter(IAppLogger logger)
        {
            _logger = logger;
            _counter = 0;
        }

        public void Count()
        {
            if (_counter++ % 3 == 0)
            {
                _logger.Info("Counter threshold reached");
            }
        }

        // added for "Spy" strategy - not in public interface
        public int CounterValue { get { return _counter; } }
    }

    public interface IBusinessCounter
    {
        void Count();
    }
}
