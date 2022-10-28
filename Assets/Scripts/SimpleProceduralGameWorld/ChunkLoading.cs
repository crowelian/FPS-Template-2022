using System.Collections.Generic;
using UnityEngine;

public class ChunkLoading : MonoBehaviour
{
    public int ChunkView;
    public static float playerRangeToHideChunks = 45f;
    public int seed = 0;
    public static System.Random RNGSingleton = new System.Random(89973);
    Vector2 PlayerChunkPos, lastPlayerChunk;
    public GameObject Player;
    public GameObject[] Chunks;
    bool ChunksLoaded;
    private List<Chunk> createdChunks = new List<Chunk>();


    private void Start()
    {
        if (seed != 0)
        {
            Debug.Log("using random seed:" + seed);
            RNGSingleton = new System.Random(seed);
        }
    }

    private void FixedUpdate()
    {
        PlayerChunkPos = new Vector2(Mathf.Floor((Player.transform.position.x + 5) / 10), Mathf.Floor((Player.transform.position.z + 5) / 10));

        if (lastPlayerChunk != PlayerChunkPos || !ChunksLoaded) LoadChunks();
    }

    private void LoadChunks()
    {
        foreach (GameObject Plane in GameObject.FindGameObjectsWithTag("Plane")) Destroy(Plane);
        lastPlayerChunk = PlayerChunkPos;
        for (int x = -ChunkView; x <= ChunkView; x++)
        {
            for (int y = -ChunkView; y <= ChunkView; y++)
            {
                if (Vector2.Distance(PlayerChunkPos, PlayerChunkPos + new Vector2(x, y)) <= ChunkView / 1.5f)
                {
                    Vector3 newChunkPos = new Vector3(x * 10 + PlayerChunkPos.x * 10, 0, y * 10 + PlayerChunkPos.y * 10);
                    for (int i = 0; i < createdChunks.Count; i++)
                    {
                        if (createdChunks[i].gameObject.transform.position == newChunkPos)
                        {
                            //Debug.LogError("CHUNK EXISTS ALREADYÄAÄAÄ");
                            return;
                        }
                    }

                    GameObject newChunk = Instantiate(RandomChunk(), newChunkPos, Quaternion.identity);
                    createdChunks.Add(newChunk.GetComponent<Chunk>());



                }

            }

        }


        ChunksLoaded = true;
    }


    GameObject RandomChunk()
    {
        // Calculate sum probabilities of all elements
        var total = 0f;
        foreach (var chunk in Chunks)
        {
            total += chunk.GetComponent<Chunk>().probability;
        }

        // Choose a random value inside the total probability
        //var random = Random.value * total;
        var random = ChunkLoading.NextFloat(RNGSingleton) * total;

        // Go through the elements again, until the chosen value is in the element's probability range
        var current = 0f;
        foreach (var chunk in Chunks)
        {
            if (current <= random && random < current + chunk.GetComponent<Chunk>().probability)
            {
                return chunk;
            }
            current += chunk.GetComponent<Chunk>().probability;
        }
        Debug.Log("RANDOM CHUNK");
        //return Chunks[(int)Random.Range(0, Chunks.Length)];
        return Chunks[(int)RNGSingleton.Next(Chunks.Length)];
    }


    static float NextFloat(System.Random random)
    {
        float randomFloat = (float)random.NextDouble();
        return randomFloat;
    }

}
