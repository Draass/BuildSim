namespace _BuildSim.Scripts.Data
{
    public static class TransportStateMachineConstants
    {
        public const string UnloadedTrigger = "Unloaded";
        public const string TargetFound = "TargetFound";
        public const string DestinationReached = "DestinationReached";
        
        public const string EnteredQueue = "EnteredQueue";
        public const string StartUnloading = "StartUnloading";
        public const string ContinueMovement = "ContinueMovement";
    }
}