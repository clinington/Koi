namespace Koi.Tests.Mocks
{
    using System;

    public interface IRepo
    {
        void Save();
    }

    public class Repo : IRepo
    {
        public void Save()
        {
            Console.WriteLine("Repo Saved.");
        }
    }
}
