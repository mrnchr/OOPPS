namespace OOPPS.Persistence
{
    public interface IDataPersistence
    {
        public void Load(GameData data);
        public void Save(GameData data);
    }
}