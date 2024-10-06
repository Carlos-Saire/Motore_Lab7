using UnityEngine;
public class PointController : MonoBehaviour
{
    public GameObject NexPoint;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            collision.gameObject.GetComponent<NPCCotroller>().SetObjetive(NexPoint);
        }
    }
}
