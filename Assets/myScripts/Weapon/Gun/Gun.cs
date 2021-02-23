using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Gun : Weapon
{
    // Start is called before the first frame update
    public float shotTimer,range,projectileNum;
    float minX,minY;
    public int currentAmmo,maxAmmo,initAmmo,addAmmoAmt;
    public GameObject bulletPrefab,impactFX; 
    public GameObject muzzle;
    public Camera cammy;
    public ParticleSystem flash;
    float nextFire = 0f;
    AudioSource fireSound;
    void Start()
    {
        fireSound = GetComponent<AudioSource>();
        currentAmmo = initAmmo;
        //Debug.Log(fireSound);
        found = false;
        held = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
        
    }

    public override void Fire(){
        if(Time.time > nextFire && currentAmmo >0){
            flash.Play();
            fireSound.Play();
            nextFire = Time.time + 1f/shotTimer;
            currentAmmo--;
            RaycastHit hit;
                if(Physics.Raycast(cammy.transform.position,cammy.transform.forward,out hit, range)){
                    Debug.Log(hit.transform.name);

                    Foe foe = hit.transform.GetComponent<Foe>();
                    if(foe != null){
                        foe.takeDamage(damage);
                    }

                    GameObject impactGO = Instantiate(impactFX, hit.point,Quaternion.LookRotation(hit.normal));

                    Destroy(impactGO,1f);
                }
                if(projectileNum > 0){
                    for (int i = 0; i < projectileNum; i++)
                    {
                        Instantiate(bulletPrefab,muzzle.transform.position,muzzle.transform.rotation);
                    }
                }
        }
        
    }

    public void AddAmmo(){
        currentAmmo += addAmmoAmt;
        if(currentAmmo>maxAmmo){
            currentAmmo=maxAmmo;
        }
    }

    public bool CheckAmmo(){
        if(currentAmmo < maxAmmo){
            AddAmmo();
            return true;
        }
        else{
            return false;
        }
    }
}
