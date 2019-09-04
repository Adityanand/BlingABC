using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{

    public List<GameObject> gems = new List<GameObject>();
    public Vector2[] shuffleArray = new Vector2[8];
    int randomIndex;
    // Use this for initialization
    void Start()
    {

        ChangePosition();
    }
    public void ChangePosition()
    {

        for (int i = 0; i < shuffleArray.Length; i++)
        {
            Vector2 temp = gems[i].transform.position;
            randomIndex = Random.Range(i, shuffleArray.Length);
            gems[i].transform.position = gems[randomIndex].transform.position;
            gems[randomIndex].transform.position = temp;


        }
    }
}