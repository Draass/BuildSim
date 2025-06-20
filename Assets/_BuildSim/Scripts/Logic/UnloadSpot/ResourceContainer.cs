using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.UnloadSpot;

namespace _BuildSim.Scripts.Logic.UnloadSpot
{
    public class ResourceContainer : IResourceContainer
    {
        public int ResourceAmount { get; private set; }
        
        public void AddResource(string resourceId, int amount)
        {
            
        }

        public void RemoveResource(int amount)
        {
            
        }
    }
}