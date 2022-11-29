using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleField : MonoBehaviour
{
    float scale = 1;
    float targetScale = 6;
    float duration = 2f;
    float initYScale;
    List<Collider> hitEnemies;
    bool end = false;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        initYScale = transform.localScale.y;

        hitEnemies = new List<Collider>();
        StartCoroutine(ExpandCircle(targetScale, duration));
    }

    // Update is called once per frame
    void Update()
    {
        // if (end){
        //     ReturnHitEnemies();
        // }
        Debug.Log(hitEnemies.Count);
    }

    public Collider[] ReturnHitEnemies(){
        Debug.Log(hitEnemies.Count);
        Collider[] hits = new Collider[hitEnemies.Count];
        int i = 0;
        foreach (Collider enemy in hitEnemies){
            hits[i] = enemy;
            i++ ;
        }
        return hits;
    }

    IEnumerator ExpandCircle(float endValue, float duration){
        float time = 0;
        float startValue = scale;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scale = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = new Vector3(startScale.x * scale, transform.localScale.y, startScale.z*scale);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(startScale.x * endValue, transform.localScale.y, startScale.z*endValue);
        scale = endValue;
        end = true;

        
    } 

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("Hit "+other.name);
        // Debug.Log("enemyLayer" + enemyLayer);
        // Debug.Log(other.gameObject.layer);
        if ((enemyLayer &(1<<other.gameObject.layer))!=0){
            if (!hitEnemies.Contains(other)){
                hitEnemies.Add(other);
            }
        }
    }
}
