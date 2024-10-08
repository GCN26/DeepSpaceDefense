using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public AmNode Node1, Node2, NodeKill;
    public AmNode[] NodeList;

    // Start is called before the first frame update
    void Start()
    {
        AmNode[] NodeList = { Node1, Node2, NodeKill };
    }

    // Update is called once per frame
    void Update()
    {
        AmNode[] NodeList = { Node1, Node2, NodeKill };
    }
}
