using UnityEngine;

public class TentacleLine : MonoBehaviour
{
    LineRenderer tentacleLine;
    GameObject player;

    private void Start()
    {
        tentacleLine = GetComponent<LineRenderer>();
        player = GameObject.FindWithTag("Player");
        tentacleLine.positionCount = 2;
        tentacleLine.startWidth = 0.8f;
        tentacleLine.endWidth = 0.8f;
    }

    private void Update()
    {
        tentacleLine.SetPosition(0, GetComponent<Transform>().position);
        tentacleLine.SetPosition(1, player.GetComponent<Transform>().position);
    }
}
