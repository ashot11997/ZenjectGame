using Zenject;

namespace UI.GameOver
{
    public class GameOverSignalInstaller : MonoInstaller<GameOverSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<GameOverSignal>();

            Container.BindSignal<GameOverSignal>()
                .ToMethod<GameOver>((x, n) => x.Toggle(n.Value))
                .FromResolve();
        }
    }
}