using UnityEngine;

public class Activate_Outgoing : MonoBehaviour
{
    public GameObject Outgoing_plant;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Z))
        {
            Outgoing_plant.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Outgoing_plant.SetActive(true);
        }
    }
}
