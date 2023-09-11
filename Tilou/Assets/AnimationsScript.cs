using UnityEngine;

public class AnimationsScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartAttack(AnimSO animData)
    {
        foreach (Collider collider in GameCore.Instance.Player.WeaponData.Colliders) { collider.enabled = true; }
        AnimationManager.Instance.SetAnimData(animData);
        Debug.Log("CALLED");
    }

    public void EndAttack()
    {
        foreach (Collider collider in GameCore.Instance.Player.WeaponData.Colliders) { collider.enabled = false; }
        GameCore.Instance.Player.WeaponData.ResetTargetHit();
        Debug.Log("CALLED");
    }
}
