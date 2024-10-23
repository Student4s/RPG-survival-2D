using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootComponent : MonoBehaviour
{
    public MainInventory inventory;
    public Weapon weapon;
    public Transform shootPoint;

    public Granade granade;
    public float maxHoldTime = 2f;
    [SerializeField] private float holdTime = 0f;

    private void Update()
    {
        //MAIN WEAPON
        if(weapon!=null)
        {
            if (Input.GetMouseButton(0))
            {
                weapon.Shoot(shootPoint);
            }
            weapon.currentTimeBTWShoot -= Time.deltaTime;
            if (weapon.isReloading)
            {
                if (weapon.currentReloadTime <= weapon.reloadTime)
                {
                    weapon.currentReloadTime += Time.deltaTime;
                }
                else
                {
                    weapon.currentReloadTime = 0f;
                    weapon.isReloading = false;
                    weapon.currentAmmo = inventory.GetAmmo(weapon.ammoType, weapon.maxAmmo);
                }
            }
        }
        //GRENADE
        if (Input.GetKey(KeyCode.G))
        {
            if (holdTime < maxHoldTime)
            {
                holdTime += Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            float throwForce = 3 + holdTime * 4;
            Debug.Log(throwForce);
            holdTime = 0f;
            var A = Instantiate(granade, shootPoint.position, shootPoint.rotation);
            A.throwForce = throwForce;
        }
    }
        
}
