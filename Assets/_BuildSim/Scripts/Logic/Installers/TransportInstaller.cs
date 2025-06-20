﻿using _BuildSim.Scripts.Logic.Transport;
using _BuildSim.Scripts.Logic.Transport.States;
using _BuildSim.Scripts.Logic.UnloadSpot;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic.Installers
{
    public class TransportInstaller : MonoInstaller
    {
        [SerializeField, Required, ChildGameObjectsOnly]
        private MonoEntity _entity;
        
        [SerializeField, Required, ChildGameObjectsOnly] 
        private PathfinderProvider _pathfinderProvider;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PathfinderProvider>().FromInstance(_pathfinderProvider).AsSingle();

            Container.BindInterfacesTo<TransportQueueController>().AsSingle();
            Container.BindInterfacesTo<TransportMovement>().AsSingle();
            
            Container.BindInterfacesTo<MovingToPositionState>().AsSingle();

            Container.BindInterfacesAndSelfTo<TransportStateMachine>().AsSingle();

            Container.BindInterfacesTo<MonoEntity>().FromInstance(_entity).AsSingle();
        }
    }
}