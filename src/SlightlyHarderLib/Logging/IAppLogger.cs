namespace SlightlyHarderLib
{
    public interface IAppLogger
    {
        void Debug(string Message);
        void Info(string Message);
        void Error(string Message);
    }
}