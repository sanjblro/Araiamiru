using UnityEngine;

public class FlowerThrower : MonoBehaviour
{
    public GameObject flowerPrefab;   // the prefab we spawn
    public Transform spawnPoint;      // where the flower appears
    public float throwForce = 10f;    // force applied to the flower

    private GameObject currentFlower;
    private Rigidbody2D currentRB;

    void Start()
    {
        SpawnNewFlower();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentFlower != null)
            {
                ThrowFlower();
            }
            else
            {
                SpawnNewFlower();
            }
        }
    }

    void ThrowFlower()
    {
        currentRB.isKinematic = false;
        currentRB.AddForce(new Vector2(1f, 1.2f) * throwForce, ForceMode2D.Impulse);

        // Remove reference so new flower can spawn on next spacebar press
        currentFlower = null;
        currentRB = null;
    }

    void SpawnNewFlower()
    {
        currentFlower = Instantiate(flowerPrefab, spawnPoint.position, Quaternion.identity);
        currentRB = currentFlower.GetComponent<Rigidbody2D>();
        currentRB.isKinematic = true; // stays still until thrown
    }
}
