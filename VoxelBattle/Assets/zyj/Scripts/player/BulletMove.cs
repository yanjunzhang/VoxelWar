﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    public string _gunName;
    float _range;
    public float _damage;
    public float _hitback;
    public float _healthUse;
    public string _bulletEffectName;
    public string _hitEffectName;
    float _playerHitBack;
    public float _bulletSpeed;
    public float _explodeRadius;
    public float _explodeDamage;
    int _canCrossWall;
	GameObject _startEffect;
	GameObject _endEffect;
    // Use this for initialization
    void Start () {
        List<PackageItems> _weapons = XML.Instance.equipsLoaded;
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_gunName==_weapons[i].name)
            {
                _range = _weapons[i].range;
                _damage = _weapons[i].damage;
                _hitback = _weapons[i].hitback;
                _healthUse = _weapons[i].healthUse;
                _bulletEffectName = _weapons[i].bulletEffectName;
                _hitEffectName = _weapons[i].hitEffectName;
                _playerHitBack = _weapons[i].playerHitBack;
                _bulletSpeed = _weapons[i].bulletSpeed;
                
                _explodeRadius = _weapons[i].exploadRadius;
                _explodeDamage = _weapons[i].explodeDamage;
                _canCrossWall = _weapons[i].canCrossWall;
                if (this.gameObject.tag == "Effect")
                {
                    _bulletSpeed = 10.1f;
                    _damage = 5f;
                }
                break;
            }
        }
        if (_canCrossWall==1)
        {
            transform.GetComponent<BoxCollider>().isTrigger = true;
        }
		GameObject[] effects = XML.Instance._effects;
		if (effects!=null) {
			foreach (var item in effects) {
				if (item.name==_bulletEffectName) {
					_startEffect = item;
				}else if (item.name==_hitEffectName) {
					_endEffect = item;
				}
				if (_startEffect!=null&&_endEffect!=null) {
					break;
				}
			}
		}

		if (_startEffect) {
			Instantiate (_startEffect, transform.position,transform.rotation);
            Destroy(_startEffect, 1f);
		}
        Invoke("Destroy", _range);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
	void FixedUpdate(){
		transform.Translate(transform.forward * Time.deltaTime * _bulletSpeed, Space.World);
	}
    void Destroy()
    {
        Destroy(this.gameObject);
    }
	void OnDestroy(){
		if (_endEffect) {
			Instantiate (_endEffect, transform.position,transform.rotation);
            Destroy(_endEffect, 1f);
		}

	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			return;
		}else{
			if (col.gameObject.tag != "Enemy" && this.gameObject.name != "arrow(Clone)") {
				Destroy (this.gameObject);
			} else{
				Destroy (this.GetComponent <BoxCollider>());
				Destroy (this.GetComponent <Rigidbody>());
				Destroy (this);
			}
		}
			

			

	}
}
