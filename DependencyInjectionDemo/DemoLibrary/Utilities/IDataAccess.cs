namespace DemoLibrary
{
    public interface IDataAccess
    {
        void LoadData();
        void SaveData(string name);
    }
}