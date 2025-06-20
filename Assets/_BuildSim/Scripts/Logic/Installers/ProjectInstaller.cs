using _BuildSim.Scripts.Logic.Common;
using Zenject;

namespace _BuildSim.Scripts.Logic.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LoadingScreenController>().AsSingle();
            Container.BindInterfacesTo<SceneLoadService>().AsSingle();
        }
    }
}