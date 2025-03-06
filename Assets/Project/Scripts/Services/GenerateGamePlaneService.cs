using System.Collections.Generic;
using UnityEngine;

public class GenerateGamePlaneService
{
    private List<BlockView> blocks = new List<BlockView>();
    private List<PawnView> pawns = new List<PawnView>();
    public List<PawnView> Pawns => pawns;
    public void Initialize(PawnSettings pawnSettings, GamePlaneView planeView) 
    {
        
        GenerateBlockPlane(pawnSettings, planeView);
        GeneratePawns(pawnSettings, planeView);
        PawnActions.RemovePawnAction += RemovePawn;
    }

    private void RemovePawn(PawnView pawn) => pawns.Remove(pawn);
    

    private void GeneratePawns(PawnSettings settings, GamePlaneView planeView)
    {
        int countPawns = settings.InitialPawnCount;

        //реализация в круге
        /* 
         float zoneRadius = settings.InitialZoneRadius;
         for (int i = 0; i < countPawns; i++)
         {
             var newPosition = UnityEngine.Random.insideUnitCircle * zoneRadius;
             var pos =new Vector3(newPosition.x, blocks[0].transform.position.y, newPosition.y) + Vector3.up * 0.8f;
             var pawn = planeView.GeneratePawns(settings.PawnPrefab, pos);
             pawns.Add(pawn);
         }*/

        //реализация по всей плоскости поля, мне кажется так лучше, в данном случае :)
        int countBlocks = blocks.Count;
        while (countPawns > 0)
        {
            for (int i = 0; i < countBlocks; i++)
            {
                var isPawn = UnityEngine.Random.Range(0, 100);
                if (isPawn > 90)
                {
                    countPawns--;
                    if (countPawns == 0)
                        return;
                    var pos = blocks[i].transform.position + Vector3.up * 0.8f;
                    var pawn = planeView.GeneratePawns(settings.PawnPrefab, pos);
                    pawns.Add(pawn);
                }
            }
        }
    }

    private void GenerateBlockPlane(PawnSettings settings, GamePlaneView planeView)
    {
        planeView.SetColors(settings.BlackCellColor, settings.WhiteCellColor);
        bool isBlack = false;
        float sizeX = settings.CheckerboardSize.x;
        float sizeY = settings.CheckerboardSize.y;
        Vector2 blockSize= new Vector3(1.5f, 1.5f);
        Vector3 offset = new Vector3((sizeX-1)* blockSize.x * 0.5f , 0, (sizeY - 1) * blockSize.y * 0.5f) ;
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                isBlack = !isBlack;
                Vector3 blockPosition = new Vector3(x * blockSize.x, -0.5f , y * blockSize.y)  - offset;
                var block = planeView.CreateBlock(settings.BlockPrefab, blockPosition, isBlack);
                blocks.Add(block);
            }
            if(sizeX%2==0) isBlack = !isBlack;
        }
    }
}
