using UnityEngine;
public class CameraFollow : MonoBehaviour
{
   public GameObject player;
   public Vector3 offset;
   public float smoothSpeed = 0.25f;


   void LateUpdate()
   {
      player = GameObject.FindWithTag("Player");
      
      transform.position = player.transform.position + offset;
   }
}
