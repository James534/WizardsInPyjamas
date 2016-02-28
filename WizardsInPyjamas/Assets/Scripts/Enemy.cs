using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject projectile;
	public int minShotInterval;
	public float damage;
	public float angleVariance;
    Player p;
	
	public GameObject player;
	private float lastTime;

    Animator anim;
    float[] animLength = new float[4];  //0=idle, 1=death, 2=attack, 3=move
    double runTime = 0;
    int curAnim = 0;
    bool dead = false;

    void Start () {
		lastTime = Time.time;
        player = GameObject.Find ("Player");
        p = player.GetComponent<Player>();

        anim = GetComponent<Animator>();
        RuntimeAnimatorController ac = anim.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name.Equals("Stand"))
            {
                animLength[0] = ac.animationClips[i].length;
            }
            else if (ac.animationClips[i].name.Equals("AttackUnarmed") ||
               ac.animationClips[i].name.Equals("Attack2HL") ||
               ac.animationClips[i].name.Equals("AttackOff"))
            {
                animLength[2] = ac.animationClips[i].length - 0.1f;
            }
            else if (ac.animationClips[i].name.Equals("Death"))
            {
                animLength[1] = ac.animationClips[i].length - 0.1f;
            }
            else if (ac.animationClips[i].name.Equals("Walk"))
            {
                animLength[3] = ac.animationClips[i].length - 0.1f;
            }
            else if (ac.animationClips[i].name.Equals("CombatWound") ||
               ac.animationClips[i].name.Equals("StandWound"))
            {
                animLength[2] = ac.animationClips[i].length;
            }
            Debug.Log(ac.animationClips[i].name + " " + ac.animationClips[i].length);
        }

    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > minShotInterval + lastTime + Random.value * 6 - 3) {
			lastTime = Time.time;
			Vector3 pos = transform.position + transform.forward*2;
			Vector3 rand = new Vector3(Random.value * angleVariance - angleVariance/2, Random.value * angleVariance - angleVariance/2, Random.value * angleVariance - angleVariance/2);
            GameObject temp = Instantiate(projectile);
            temp.transform.position = pos;
            temp.transform.LookAt(player.transform.position);

            SphereCollider temp2 = temp.GetComponent<SphereCollider>();
            temp2.transform.SetParent(temp.transform);
            Attack();
        }
        if (curAnim != 0)
        {
            if (anim.GetTime() - runTime > animLength[curAnim])
            {
                if (curAnim == 1)
                {
                    this.transform.position = new Vector3(-5000, -5000, 0);
                    dead = true;
                }

                anim.Play("Idle");
            }
        }
    }

    public void Attack()
    {
        anim.Play("Attack");
        runTime = anim.GetTime();
        curAnim = 2;
    }
    public void Death()
    {
        anim.Play("Death");
        runTime = anim.GetTime();
        curAnim = 1;
    }

    public void hit(int mana)
	{
		GameObject.Find ("GameObject").gameObject.GetComponent<RandomEnemyGen> ().kill (this.gameObject);
        p.addMana(mana);
	}
}
