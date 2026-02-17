using UnityEngine;

public class EnemyInteractable : MonoBehaviour
{
    
    
    [SerializeField]
    private AreaOfEngagementTrigger areaOfEngagementTrigger;

    [SerializeField] 
    private LineOfSightTrigger lineOfSightTrigger;

    [SerializeField]
    private WeakSpotTrigger weakSpotTrigger;
    
}
