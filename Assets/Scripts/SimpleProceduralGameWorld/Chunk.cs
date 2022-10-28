using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector3 chunkPosition;
    private GameObject player;
    private float hideRange = 5f;

    [Range(0.01f, 1f)]
    public float probability = 0.5f;

    private void Start()
    {
        chunkPosition = transform.position;
        hideRange = ChunkLoading.playerRangeToHideChunks;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > hideRange)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
                
        }
        if (dist < hideRange)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chunk")
        {
            Destroy(gameObject);
        }
    }
}
