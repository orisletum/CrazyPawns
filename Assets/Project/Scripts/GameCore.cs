using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCore : MonoBehaviour
{
    [Inject] public PawnSettings settings;
    [Inject] public GamePlaneView planeView;

    private void Start()
    {
        GenerateScene().Forget();
    }
    public async UniTask GenerateScene()
    {

        GenerateGamePlaneService planeService = new GenerateGamePlaneService();
        CreateConnectionService createConnectionService = new CreateConnectionService();
        GroundCheckService groundCheckService = new GroundCheckService();
       

        await UniTask.Delay(100);

        planeService.Initialize(settings, planeView);
        groundCheckService.Initialize(settings, planeService);
        createConnectionService.Initialize(settings, planeView, planeService);
    }

    
}
