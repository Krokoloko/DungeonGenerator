using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {
    [Tooltip("1 = up; 2 = right; 3 = down; 4 = left")]
    public int direction;

    private int _rand;
    public bool spawned;
    private Rooms roomCollection;
    /*
     *1 = up 
     *2 = right
     *3 = down
     *4 = left
	*/
	void Start () {
        roomCollection = GameObject.FindGameObjectWithTag("Holder").GetComponent<Rooms>();

        if (GameObject.FindGameObjectsWithTag("Room").Length <= 15)
        {
            Invoke("Spawn", 0.4f);
            Debug.Log("Spawn");
        }
        else
        {
            Debug.Log("limit");
        }
    }

    void Spawn()
    {
        
        switch (direction)
        {
            case 1:
                _rand = Random.Range(0, roomCollection.bottomGate.Length);
                Instantiate(roomCollection.bottomGate[_rand], gameObject.transform.position, Quaternion.Euler(-90,0,0));
                break;
            case 2:
                _rand = Random.Range(0, roomCollection.leftGate.Length);
                Instantiate(roomCollection.leftGate[_rand], gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                break;
            case 3:
                _rand = Random.Range(0, roomCollection.topGate.Length);
                Instantiate(roomCollection.topGate[_rand], gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                break;
            case 4:
                _rand = Random.Range(0, roomCollection.rightGate.Length);
                Instantiate(roomCollection.rightGate[_rand], gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                break;
        }
        spawned = true;
    }

    private int PolarDirection(int x)
    {
        switch (x)
        {
            case 1:
                return 3;
            case 2:
                return 4;
            case 3:
                return 1;
            case 4:
                return 2;
            default:
                return x;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }

        /*if (!collision.gameObject.GetComponent<RoomSpawner>().spawned && !spawned)
        {
            if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
            {
                int[] coord = new int[2] { direction, collision.gameObject.GetComponent<RoomSpawner>().direction };
                
                int[] desiredcoord = new int[2] {PolarDirection(direction), PolarDirection(collision.gameObject.GetComponent<RoomSpawner>().direction) };

                for (int i = 0; i < roomCollection.topGate.Length;i++)
                {
                    foreach(Transform obj in roomCollection.topGate[i].transform)
                    {
                        if (obj.name == "Checkpoints")
                        {
                            foreach (Transform waypoint in obj)
                            {
                                //waypoint.gameObject.GetComponent<RoomSpawner>().direction;
                            }
                        }
                    }
                }

                switch (collision.gameObject.GetComponent<RoomSpawner>().direction)
                {
                    case 1:
                        switch (direction)
                        {
                            case 1:

                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }
        }*/
    }
}

