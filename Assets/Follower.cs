using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2f; // How far behind the follower is
    public float minMoveThreshold = 0.01f;

    private Queue<Vector3> positionHistory = new Queue<Vector3>();
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
        // Fill queue with initial position so it doesn't snap wildly at start
        for (int i = 0; i < 15; i++)
        {
            positionHistory.Enqueue(player.position);
        }
    }

    void Update()
    {
        // Check if player moved
        if (Vector3.Distance(player.position, lastPlayerPosition) > minMoveThreshold)
        {
            positionHistory.Enqueue(player.position);
            lastPlayerPosition = player.position;

            // Remove the oldest position to keep the queue size steady
            if (positionHistory.Count > 20)
            {
                positionHistory.Dequeue();
            }
        }

        // Apply position if waiting queue has data
        if (positionHistory.Count > 0)
        {
            transform.position = positionHistory.Peek();
        }
    }
}