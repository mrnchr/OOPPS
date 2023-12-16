using System;

namespace OOPPS.Persistence
{
    public class NewGameCreator : INewGameCreator
    {
        public void Create(GameData data)
        {
            data.Resources.Energy.StartResetTime = DateTime.Now;
        }
    }

    public interface INewGameCreator
    {
        public void Create(GameData data);
    }
}