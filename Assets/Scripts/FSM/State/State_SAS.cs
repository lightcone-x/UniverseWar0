﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//RCS关，SAS开，有姿态稳定，ASDRF失效，QE↑↓←→改为transfrom控制
public class State_SAS : BaseState
{
    public State_SAS(SpaceShip spaceShip)
    {
        base.spaceShip = spaceShip;
    }

    public override void OnEnter()
    {
        spaceShip.rigi.angularDrag = spaceShip.SasForce;  // 当sas开启 rcs关闭时 旋转阻力为1（姿态稳定）
    }

    public override void OnFixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 force = spaceShip.transform.forward * spaceShip.MainEngine;
            Vector3 force1 = spaceShip.transform.forward * spaceShip.MainEngine;

            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["main_engine"].transform.position); // 受力
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["main_engine1"].transform.position);

            /* Rigidbody rigi = gameObject.GetComponent<Rigidbody>();
             Vector3 force = transform.forward * MainEngine;
             //main_engine.transform.forward * MainEngine;
             //Vector3 direction = main_engine.transform.position * MainEngine;
             rigi.AddForce(force);


             GameObject _flame = Instantiate(flame, main_engine.position, main_engine.rotation);
             _flame.transform.SetParent(this.transform);//实例化火焰*/

            /*Vector3 force = transform.forward * MainEngine;

            GameObject _flame = Instantiate(flame, main_engine.position, main_engine.rotation); // 先生成火焰
            rigi.AddForceAtPosition(force, _flame.transform.position); // 后进行受力

            _flame.transform.SetParent(this.transform);*///实例化火焰


        }

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 force = spaceShip.transform.up * spaceShip.RcsEngine;
            Vector3 force1 = spaceShip.transform.up * -spaceShip.RcsEngine;


            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["right_up"].transform.position);
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["left_down"].transform.position);



            //spaceShip.transform.Rotate(Vector3.forward * spaceShip.SasForce);

            /*Vector3 force = transform.forward * -RcsEngine;
            Vector3 force1 = transform.forward * RcsEngine;

            GameObject _flame = Instantiate(flame, right_forward_up.position, right_forward_up.rotation);
            GameObject _flame1 = Instantiate(flame, right_back_up.position, right_back_up.rotation);
            rigi.AddForceAtPosition(force, _flame.transform.position);
            rigi.AddForceAtPosition(force1, _flame1.transform.position);

            _flame.transform.SetParent(this.transform);
            _flame1.transform.SetParent(this.transform);*/
        }

        if (Input.GetKey(KeyCode.E))
        {
            //spaceShip.transform.Rotate(Vector3.forward * -spaceShip.SasForce);

            Vector3 force = spaceShip.transform.up * -spaceShip.RcsEngine;
            Vector3 force1 = spaceShip.transform.up * spaceShip.RcsEngine;


            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["right_down"].transform.position);
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["left_up"].transform.position);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 force = spaceShip.transform.up * -spaceShip.RcsEngine;
            Vector3 force1 = spaceShip.transform.up * spaceShip.RcsEngine;


            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["up_forward"].transform.position);
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["down_back"].transform.position);

            /*Vector3 force = transform.forward * RcsEngine;
            Vector3 force1 = transform.forward * -RcsEngine;

            GameObject _flame = Instantiate(flame, up_forward.position, up_forward.rotation);
            GameObject _flame1 = Instantiate(flame, down_back.position, down_back.rotation);
            rigi.AddForceAtPosition(force, _flame.transform.position);
            rigi.AddForceAtPosition(force1, _flame1.transform.position);

            _flame.transform.SetParent(this.transform);
            _flame1.transform.SetParent(this.transform);*/

            spaceShip.transform.Rotate(Vector3.right * spaceShip.SasForce);

            //down_back.AddForceAtPosition(force, down_back.transform.position + new Vector3(0.0f, 0.3f, 0.0f), ForceMode.Force);
            //down_back.AddForce(Vector3.right * 15f, ForceMode.Force);



            /*Rigidbody rigi = gameObject.GetComponent<Rigidbody>();
            Vector3 force = down_back.transform.right * RcsEngine;
            Vector3 force1 = up_forward.transform.right * -RcsEngine;
            rigi.AddForce(force);
            rigi.AddForce(force1);*/

            /*GameObject _flame = Instantiate(flame, down_back.position, down_back.rotation);
             GameObject _flame1 = Instantiate(flame, up_forward.position, up_forward.rotation);
             _flame.transform.SetParent(this.transform);
             _flame1.transform.SetParent(this.transform);*/

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 force = spaceShip.transform.up * spaceShip.RcsEngine;
            Vector3 force1 = spaceShip.transform.up * -spaceShip.RcsEngine;

            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["down_forward"].transform.position);
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["up_back"].transform.position);

            //spaceShip.transform.Rotate(-Vector3.right * spaceShip.SasForce);


        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 force = spaceShip.transform.forward * spaceShip.RcsEngine;
            Vector3 force1 = spaceShip.transform.forward * -spaceShip.RcsEngine;

            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["right_forward"].transform.position);
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["left_back"].transform.position);


            //spaceShip.transform.Rotate(-Vector3.up * spaceShip.SasForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 force = spaceShip.transform.forward * spaceShip.RcsEngine;
            Vector3 force1 = spaceShip.transform.forward * -spaceShip.RcsEngine;

            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["left_forward"].transform.position);
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["right_back"].transform.position);
            //spaceShip.transform.Rotate(Vector3.up * spaceShip.SasForce);


        }
    }

    public override void OnExit()
    {

    }
}
