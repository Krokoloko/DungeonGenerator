using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    private float[,] _grid;
    public int width, height;
    public int rectWidth, rectLength;
    public Material mat;
    public Sprite sprite;
    private Vector3[] _directions; 


	void Start () {
        Debug.Log("Hello Periln");
        _grid = new float[width, height];
        _directions = new Vector3[4];
        _directions[0] = new Vector3(0.5f,0.5f);
        _directions[1] = new Vector3(-0.5f,0.5f);
        _directions[2] = new Vector3(0.5f,-0.5f);
        _directions[3] = new Vector3(-0.5f,-0.5f);
        CreateNoise();
	}
	public float Perlin(float x, float y, float z)
    {
        Vector3 cord = new Vector3(x, y, z);
        return cord.magnitude % 1f;
    }

    public float Perlin(Vector3 vec)
    {
        return vec.magnitude % 1f;
    }
    
    private void CreateNoise()
    {
        
        int squares = (width / rectWidth) * (height / rectLength);
        int[] wr = new int[squares];
        int[] lr = new int[squares];
        Debug.Log(width/rectWidth + " : " + height/rectLength);
        for (int i = 0; i < squares;i++)
        {
            wr[i] = Random.Range(0, rectWidth) + (rectWidth * (i%(squares/rectLength)));
            lr[i] = Random.Range(0, rectLength) + (rectLength * (i%(squares/rectWidth)));
            //Debug.Log("" + wr[i] + " : " + lr[i] + "");
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject obj = new GameObject(i + ":" + j);
                obj.AddComponent<SpriteRenderer>();
                obj.GetComponent<SpriteRenderer>().material = new Material(mat)
                {
                    color = new Color(0, 0, 0, _grid[i, j])
                };
                obj.GetComponent<SpriteRenderer>().sprite = sprite;
                //Instantiate<GameObject>(obj, new Vector3(i*obj.GetComponent<SpriteRenderer>().sprite.rect.width/2,
                 //                                       j*obj.GetComponent<SpriteRenderer>().sprite.rect.height/2,
                   //                                     0),Quaternion.identity);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
