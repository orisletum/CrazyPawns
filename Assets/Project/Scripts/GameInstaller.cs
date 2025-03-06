using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Vector3 gamePlanePosition = new Vector3(0, 0.5f, 0);
        var go = new GameObject("CustomObject");
        go.transform.position = gamePlanePosition;
        go.name = "GamePlane";
        var gamePlane = go.AddComponent<GamePlaneView>();
        Container.Bind<GamePlaneView>().FromInstance(gamePlane).AsSingle();
     
    }
}
