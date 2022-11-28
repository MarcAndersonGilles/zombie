using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScriptText : MonoBehaviour
{
    public Text text;
    public float lifeTime = 0.6f;
    private float minDist = 2f;
    public float maxDist = 3f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2* transform.position - Camera.main.transform.position);
        float direction = Random.rotation.eulerAngles.z;
        iniPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        targetPos = iniPos + (Quaternion.Euler(0,0, direction)* new Vector3(dist,dist, 0f));
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float fraction = lifeTime / 2f;



        if (timer > lifeTime) Destroy(gameObject);
        else if (timer > fraction) text.color = Color.Lerp(text.color, Color.clear, (timer - fraction) / (lifeTime - fraction));
        


            transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer/ lifeTime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer/ lifeTime));
    }

    public void SetDamageText(int damage)
    {
        text.text = damage.ToString();
    }
}
