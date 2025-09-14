using UnityEngine;

public class MoveUI : MonoBehaviour
{
   public void TriggerUI()
   {
      GetComponent<Animation>().Play();
   }
}
