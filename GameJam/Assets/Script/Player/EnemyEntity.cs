using UnityEngine;
using System.Collections;

public class EnemyEntity : BaseEntity 
{
    public StateMachine<EnemyEntity> FSM = new StateMachine<EnemyEntity>();
	
	public GameObject playerclone;
    public Transform target;
    public float seekThreshold = 0;
    public float attackThreshold = 0;
	
	public Material infected;
	public int maxHealth = 100;
	public int health;
	public float regenHealthTime = 1f;
	public int regenAmount = 10;
	private int nubclone;
	public int maxNubClone = 2;
	public float destroyTime = 5f;

    public void Start()
    {
        base.Start();
        FSM.Configure(this, Idle.Instance);
		if(playerclone == null){
			playerclone = GameObject.FindGameObjectWithTag("PlayerClone");
		}
		health = maxHealth;
		StartCoroutine(Regenerate());
    }


    public override Vector2 InputMovement()
    {
        if (FSM.CurrentState == Seek.Instance)
        {
            Vector3 targetDir = (target.position - trans.position).normalized;
            return new Vector2(targetDir.x, targetDir.z);
        }
        else
        {
            //print("stop");
            return Vector2.zero;
        }
    }

    public void Update()
    {
        FSM.Update();
		
		if(health <= 0)
		{
		
			GetComponent<SphereCollider>().enabled=false;
			this.gameObject.renderer.material = infected;
			Timed t = GetComponent<Timed>();
			t.m_Mat = this.gameObject.renderer.material;
			t.enabled = true;
			if(nubclone <= maxNubClone){
				Instantiate(playerclone,this.gameObject.transform.position,Quaternion.identity);
				nubclone++;
			}
			
			StartCoroutine(destroyCell());
		}
    }
    


    public float CheckDistanceToTarget()
    {
        if (target != null)
        {
            return (target.position - trans.position).magnitude;
        }
        return seekThreshold;
    }
	
	public void ApplyDamage(int damage)
	{
		health -= damage;
	}
	
	IEnumerator Regenerate()
	{
		while(true)
		{
			yield return new WaitForSeconds(regenHealthTime);
			health += regenAmount;
			
			if(health > maxHealth)
			{
				health = maxHealth;
			}
		}
	}
	
	IEnumerator destroyCell()
	{
		yield return new WaitForSeconds(destroyTime);
		Destroy(this.gameObject);
	}
}
