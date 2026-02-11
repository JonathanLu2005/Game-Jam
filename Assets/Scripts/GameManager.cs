using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState : MonoBehaviour
{

    public BattleBoxCore BattleBox;
    public Transform PlayerTransform;
    public TurretSystem TurretSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TimedLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Queue<TurretConfig> turrets = new Queue<TurretConfig>();
    private int numTurrets;
    IEnumerator TimedLoop()
    {
        
        // Stage switch every 10 seconds
        while (true)
        {
            // Phase 1
            //if (BattleBox.currentShape == BattleBoxCore.BoxShape.FullScreenRectangle)
            //{
            //    BattleBox.SetShape(BattleBoxCore.BoxShape.MiniSquare);
            //}
            //else
            //{
            //    BattleBox.SetShape(BattleBoxCore.BoxShape.FullScreenRectangle);
            //}

            // Spawn a new orbiting turret

            
            //Debug.Log(numTurrets);
            if (numTurrets< 3)
            {
                TurretConfig turret = TurretSystem.Spawn(new OrbitOptions(
                    new Vector2(10, 0), 
                    orbitRadius: 11f, 
                    orbitSpeed: 20f, 
                    fireRatePerSecond:0.5f
                ));
                turrets.Enqueue(turret);
                numTurrets++;
            }

            else if (numTurrets == 3) { 
                for(int i =0; i < 3; i++)
                {
                    TurretSystem.Release(turrets.Dequeue());
                    numTurrets--;
                }
            }
            yield return new WaitForSeconds(3f);
        }

    }
}
