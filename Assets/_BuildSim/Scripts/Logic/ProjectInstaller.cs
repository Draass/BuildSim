using Zenject;

namespace _BuildSim.Scripts.Logic
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