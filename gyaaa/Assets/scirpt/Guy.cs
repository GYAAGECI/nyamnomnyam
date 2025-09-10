using UnityEngine;

public class Guy : MonoBehaviour{
    public string myCol;
    Transform targetPos;

    public void SetTarget(Transform newTarget){
        targetPos = newTarget;
    }

    void Update(){
        if(targetPos != null){
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos.position, 10 * Time.deltaTime);
        }
    }
}