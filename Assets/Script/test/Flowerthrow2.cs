using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerthrow2 : MonoBehaviour
{
    public GameObject flowerPrefab;
    public Transform holdPoint;
    public Transform throwDirection;
    public float throwForce = 10f;

    private GameObject currentFlower;
    private Rigidbody2D currentRB;

    void Update()
    {
        // ถ้า winButton เด้งขึ้น → ไม่ให้โยนดอกไม้
        if (ScoreManager2.Instance.winButton.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentFlower == null)
            {
                SpawnFlower();
            }
            else
            {
                ThrowFlower();
            }
        }
    }


    void SpawnFlower()
    {
        currentFlower = Instantiate(flowerPrefab, holdPoint.position, Quaternion.identity);
        currentFlower.transform.SetParent(holdPoint);
        currentFlower.transform.localPosition = Vector3.zero;

        currentRB = currentFlower.GetComponent<Rigidbody2D>();
        currentRB.isKinematic = true;
    }

    void ThrowFlower()
    {
        currentFlower.transform.SetParent(null);
        currentRB.isKinematic = false;

        Vector2 dir = (throwDirection.position - holdPoint.position).normalized;
        currentRB.AddForce(dir * throwForce, ForceMode2D.Impulse);

        currentFlower = null;

        // spawn ดอกใหม่หลังจากโยนเสร็จ
        Invoke(nameof(SpawnFlower), 0.25f);
    }
}