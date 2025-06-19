namespace _BuildSim.Scripts.Data.States
{
    public enum TransportState
    {
        Idle = 0,
        MovingToUnloadSpot = 1,
        WaitingInQueue = 2,
        Unloading = 3,
        LeavingMap = 4
    }
}