using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public int numBgCount = 5;
    public Vector3 obstacleLasttPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        //Obstacle이라는 컴포넌트가 붙어있는 게임오브젝트 배열 반환
        Obstacle[] obstacle = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLasttPosition = obstacle[0].transform.position;
        obstacleCount = obstacle.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLasttPosition = obstacle[i].SetRandomPlace(obstacleLasttPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger: {collision.name}");

        if (collision.CompareTag("BackGround"))
        {
            // collision이 모든 클래스의 부모이고 size에 대한 정보가 없기 때문에 BoxCollider로 캐스팅 해줘야함
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return; // obstacle 판정 안하도록 
        }


        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLasttPosition = obstacle.SetRandomPlace(obstacleLasttPosition, obstacleCount);
        }
    }
}
