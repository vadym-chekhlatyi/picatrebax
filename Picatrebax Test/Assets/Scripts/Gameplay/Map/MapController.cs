using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance;

    [SerializeField] private Transform ground;
    [SerializeField] private Transform roof;

    [Space]
    [Header("Block Prefab")]
    [SerializeField] private GameObject Block;

    [Space]
    [Header("Generation Properties")]
    [SerializeField] private int minSize;
    [SerializeField] private int minSpacing;
    [SerializeField] private int maxSpacing;

    [Space]
    [Header("Properties")]
    [SerializeField] public float speed;
    [SerializeField] private float speedIncreaseOverTime;

    private float lastGroundPosition;
    private float lastRoofPosition;

    private int lastGroundSize;
    private int lastRoofSize;

    void Start()
    {
        Instance = this;

        lastGroundPosition = 0f;
        lastRoofPosition = 0f;

        lastGroundSize = 1920;
        lastRoofSize = 1920;

        GenerateGround();
        GenerateRoof();
    }

    // Increasing the speed over time to escalate difficulty   //
    // - - - - - And also moving the roof and ground - - - - - //
    private void FixedUpdate()
    {
        if (Gameplay.Instance.gameActive)
        {
            speed += speedIncreaseOverTime * Time.deltaTime;
            ground.position += Vector3.left * speed * Time.deltaTime;
            roof.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    public void GenerateGround()
    {
        int randomSpacing = UnityEngine.Random.Range(minSpacing, maxSpacing);
        int randomSize = UnityEngine.Random.Range(minSize, Screen.width / 2);

        // Finding a new position for block by addind sizes and spacing of a prev and current blocks
        float newX = lastGroundPosition + (lastGroundSize / 2) + randomSpacing + (randomSize / 2);

        GameObject newBlock = Instantiate(Block, ground);

        SetupProperties(newBlock, randomSize, newX);

        lastGroundPosition = newX;
        lastGroundSize = randomSize;
    }

    public void GenerateRoof()
    {
        int randomSpacing = UnityEngine.Random.Range(minSpacing, maxSpacing);
        int randomSize = UnityEngine.Random.Range(minSize, Screen.width / 2);

        // Finding a new position for block by addind sizes and spacing of a prev and current blocks
        float newX = lastRoofPosition + (lastRoofSize / 2) + randomSpacing + (randomSize / 2);

        GameObject newBlock = Instantiate(Block, roof);

        SetupProperties(newBlock, randomSize, newX);

        lastRoofPosition = newX;
        lastRoofSize = randomSize;
    }

    private void SetupProperties(GameObject newBlock, int randomSize, float newX)
    {
        newBlock.GetComponent<RectTransform>().sizeDelta = new Vector2(randomSize, 100f);
        newBlock.GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, 0f);
        newBlock.GetComponent<BoxCollider2D>().size = new Vector2(randomSize, 100f);
    }

    // When the block touches the trigger => it generates next block
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.name == "Ground")
            GenerateGround();
        else
            GenerateRoof();
    }
}
