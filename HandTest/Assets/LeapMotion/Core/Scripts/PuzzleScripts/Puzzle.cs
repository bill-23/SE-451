using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puzzle : MonoBehaviour
{

    public Texture2D image;
    public int blocksPerLine = 4;

    Block emptyBlock;

    void Start()
    {
        CreatePuzzle();
    }

    void CreatePuzzle()
    {
        Texture2D[,] imageSlices = ImageSlicer.GetSlices(image, blocksPerLine);
        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                blockObject.transform.position = new Vector2(x, y);
                blockObject.transform.parent = transform;

                Block block = blockObject.AddComponent<Block>();

                //Added mesh collider to each block object so we can interact with it
                MeshCollider block2 = blockObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
                block2.convex = true;
                block2.isTrigger = true;
                

                block.OnBlockPressed += PlayerMoveBlockInput;
                block.Init(new Vector2Int(x, y), imageSlices[x, y]);

                if (y == 0 && x == blocksPerLine - 1)
                {
                    blockObject.SetActive(false);
                    emptyBlock = block;
                }
            }
        }

    }

    void PlayerMoveBlockInput(Block blockToMove)
    {
        if ((blockToMove.coord - emptyBlock.coord).sqrMagnitude == 1)
        {
            Vector2Int targetCoord = emptyBlock.coord;
            emptyBlock.coord = blockToMove.coord;
            blockToMove.coord = targetCoord;

            Vector2 targetPosition = emptyBlock.transform.position;
            emptyBlock.transform.position = blockToMove.transform.position;
            blockToMove.transform.position = targetPosition;
        }
    }
}

