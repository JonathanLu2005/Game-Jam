using Unity.VisualScripting;
using UnityEngine;


/**
 * This class is responsible for resizing the battle box. It is NOT responsible for any movement.
 */
public class BattleBoxGeometry : MonoBehaviour
{
    [Header("Walls")]
    public Transform leftWall;
    public Transform rightWall;
    public Transform topWall;
    public Transform bottomWall;

    public BoxCollider2D leftCol;
    public BoxCollider2D rightCol;
    public BoxCollider2D topCol;
    public BoxCollider2D bottomCol;

    float wallThickness;
    Vector2 fullScreenDims;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wallThickness = leftCol.size.x;
        fullScreenDims = new Vector2(18, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(Vector2 size)
    {
        float halfW = size.x * 0.5f;
        float halfH = size.y * 0.5f;

        // Move walls, this is relative to the parent, so when the parent moves the box shape is maintained
        leftWall.localPosition = new Vector3(-halfW, 0f);
        rightWall.localPosition = new Vector3(halfW, 0f);
        topWall.localPosition = new Vector3(0f, halfH);
        bottomWall.localPosition = new Vector3(0f, -halfH);

        // Shorten/lengthen walls
        leftWall.localScale = new Vector3(1, size.y);
        rightWall.localScale = new Vector3(1, size.y);
        topWall.localScale = new Vector3(size.x + wallThickness, 1);
        bottomWall.localScale = new Vector3(size.x + wallThickness, 1);

        // Adjust collider
        SetCollider(topCol, size.x, wallThickness);
        SetCollider(bottomCol, size.x, wallThickness);

        SetCollider(leftCol, wallThickness, size.y);
        SetCollider(rightCol, wallThickness, size.y);
    }

    void SetCollider(BoxCollider2D col, float x, float y)
    {
        col.size = new Vector2(x, y);
    }
}
