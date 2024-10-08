using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Background : MonoBehaviour
{
    public AmNode[] nodes;
    //node index
    int currentNode = 0;
    //obvious
    public float speed;
    //How close the object must be to a node
    public float tolerance;

    public GameObject background;

    public GameObject manager;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = nodes[currentNode].transform.position;
        Vector3 direction = targetPosition - this.transform.position;
        direction = direction.normalized;

        //move the object in dir of their target at specified speed
        this.transform.position += direction * speed * Time.deltaTime;

        //if distance between object is less than tolerance
        if (Vector3.Distance(targetPosition, this.transform.position) < tolerance)
        {
            //increase current node by 1 and move on to next target
            currentNode = currentNode + 1;

            currentNode = currentNode % nodes.Length;
        }
        if (currentNode == 2)
        {
            GameObject bg2;
            bg2 = Instantiate(background, new Vector3(0,13,0), transform.rotation);
            bg2.name = "BG";
            bg2.GetComponent<Background>().manager = manager;
            bg2.GetComponent<Background>().nodes = manager.GetComponent<BackgroundManager>().NodeList;
            bg2.GetComponent <Background>().speed = speed;
            Destroy(this.gameObject);
        }
    }
}
