using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller", order = 51)]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private PawnSettings pawnSettings;


    public override void InstallBindings()
    {
        Container.BindInstance(pawnSettings).AsSingle();
    }
}