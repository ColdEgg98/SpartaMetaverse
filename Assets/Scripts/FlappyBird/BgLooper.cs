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
        //Obstacle�̶�� ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ �迭 ��ȯ
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
            // collision�� ��� Ŭ������ �θ��̰� size�� ���� ������ ���� ������ BoxCollider�� ĳ���� �������
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return; // obstacle ���� ���ϵ��� 
        }


        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLasttPosition = obstacle.SetRandomPlace(obstacleLasttPosition, obstacleCount);
        }
    }
}
