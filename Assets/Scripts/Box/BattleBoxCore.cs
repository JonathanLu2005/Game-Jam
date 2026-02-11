using UnityEngine;
using UnityEngine.LowLevelPhysics;

/**
 * This is the main class for all behaviours and attributes for the battle box.
 *
 */
public class BattleBoxCore : MonoBehaviour
{


    public enum BoxShape { 
        FullScreenRectangle,
        MiniSquare
    }

    Vector2 ResolveShape(BoxShape mode)
    {
        switch (mode)
        {
            case BoxShape.FullScreenRectangle: return new Vector2(18, 10);
            case BoxShape.MiniSquare: return new Vector2(6, 6);
            default: return Vector2.one * 8;
        }
    }

    [Header("Shape")]
    public BoxShape currentShape;

    BattleBoxGeometry geometry;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        geometry = GetComponent<BattleBoxGeometry>();
        geometry.SetSize(ResolveShape(currentShape));
    }

    public void AlternateShape()
    {
        if (currentShape ==BoxShape.FullScreenRectangle)
        {
            SetShape(BoxShape.MiniSquare);
        }
        else
        {
            SetShape(BoxShape.FullScreenRectangle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetShape(BoxShape newShape) {
        Debug.Log(newShape);
        currentShape = newShape;
        geometry = GetComponent<BattleBoxGeometry>();
        geometry.SetSize(ResolveShape(newShape));
    }
}
