using Zenject;

namespace UI.GameWin
{
    public class GameWinSignalInstaller : MonoInstaller<GameWinSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<GameWinSignal>();

            Container.BindSignal<GameWinSignal>().ToMethod<GameWin>((x, n) => x.Toggle(n.Value)).FromResolve();
        }
    }
}
