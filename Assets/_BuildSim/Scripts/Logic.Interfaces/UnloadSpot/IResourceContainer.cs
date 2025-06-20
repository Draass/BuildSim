namespace _BuildSim.Scripts.Logic.Interfaces.UnloadSpot
{
    public interface IResourceContainer
    {
        int ResourceAmount { get; }
        
        void AddResource(string resourceId, int amount);

        void RemoveResource(int amount);
    }
}