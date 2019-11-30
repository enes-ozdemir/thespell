using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void Start()
    {
        var physicsMotion = GetComponentInChildren<RFX4_PhysicsMotion>(true);
        if (physicsMotion != null) physicsMotion.CollisionEnter += CollisionEnter;

        var raycastCollision = GetComponentInChildren<RFX4_RaycastCollision>(true);
        if (raycastCollision != null) raycastCollision.CollisionEnter += CollisionEnter;
    }

    private void CollisionEnter(object sender, RFX4_PhysicsMotion.RFX4_CollisionInfo e)
    {
        var enemy = e.HitGameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("2. Büyü düşmana çarptı dostumm");
            GameController.AttackToEnemy(enemy);
        }
    }

}
