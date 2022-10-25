namespace sampleApp.Services.IService
{
    public interface IFileHelper
    {
        List<T> ReadFile<T>() where T : class;
        void WriteFile(string data);
    }

}
