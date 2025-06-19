namespace _BuildSim.Scripts.Data.States
{
    public enum TransportState
    {
        None,
        Idle,
        MovingToUnloadSpot,
        WaitingInQueue,
        Unloading,
        LeavingMap
    }
}