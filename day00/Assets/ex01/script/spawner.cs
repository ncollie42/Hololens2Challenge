using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject cubeA;
    [SerializeField] private GameObject cubeS;
    [SerializeField] private GameObject cubeD;
    public Queue<GameObject> A = new Queue<GameObject>();
    public Queue<GameObject> S = new Queue<GameObject>();
    public Queue<GameObject> D = new Queue<GameObject>();

    public float score = 0;
    [SerializeField] Text scoreText; 
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject tmpA = Instantiate(cubeA, new Vector3(-2.6F, 0, 0), Quaternion.identity);
        A.Enqueue(tmpA);
        GameObject tmpS = Instantiate(cubeS, transform.position, Quaternion.identity);
        S.Enqueue(tmpS);
        GameObject tmpD = Instantiate(cubeD, new Vector3(2.6F, 0, 0), Quaternion.identity);
        D.Enqueue(tmpD);
       

    }

    // Update is called once per frame
    void Update()
    {
 
        scoreText.text = score.ToString();
        if(Input.GetKeyDown(KeyCode.A))
        {
            GameObject tmp = A.Dequeue();
            updateScore(tmp);
            tmp.GetComponent<cubes>().Restart();       
            A.Enqueue(tmp);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject tmp = S.Dequeue();
            updateScore(tmp);
            tmp.GetComponent<cubes>().Restart();
           
            S.Enqueue(tmp);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject tmp = D.Dequeue();
            updateScore(tmp);
            tmp.GetComponent<cubes>().Restart();
      
            D.Enqueue(tmp);
        }
    }

    void updateScore(GameObject obj)
    {
        var tmp = obj.transform.position.y * -1;
        if (tmp > 8)
            score += tmp;
        else
            score -= 7;
        print(tmp);
    }
}
