using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEsf : MonoBehaviour
{
    private Vector3 PosEsf1, PosEsf2;
    private GameObject Sphere3, Sphere2;
    float LimU = 50f;
    float LimD = -50f;
    float LimR = 50f;
    float LimL = -50f;
    float Rad = 5f, Rad2 = 10f;
    public float V1x,V1z, V2x, V2z;
    float M1, M2, e = 2.71828f;

    void Start()
    {
        Sphere2 = GameObject.Find("Esf2");
        PosEsf2 = Sphere2.GetComponent<Transform>().position;
        V1x = 0; V1z = 0; V2x = 0; V2z = 0; M1 = 1; M2 = 1;
    }
    void Update()
    {
       
        PosEsf1 = gameObject.GetComponent<Transform>().position;
        if (Input.GetKey(KeyCode.UpArrow)&&(PosEsf1.z + Rad) < LimU)
        {
            if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.x - PosEsf2.x), 2) + Mathf.Pow((PosEsf1.z - PosEsf2.z), 2))) > (Rad2)) //si las esferas no se tocan
            {
      
                V1z = V1z + 1f;
            }
            else //si si se tocan
            {
               
                if (LimU >= (PosEsf2.z + Rad) && (PosEsf2.z > PosEsf1.z)) //revisar si no se tocan contra pared
                {
                    V2z = (((1 + e) * M1) / (M1 + M2)) * V1z ;
                    PosEsf2.z = PosEsf2.z + Time.fixedDeltaTime * V2z;
       
                    PosEsf1.z = PosEsf1.z + 1f;
                }


                if (PosEsf2.z < PosEsf1.z)
                {
                    PosEsf1.z = PosEsf1.z + 1f;
                    V1z = V1z + 1f;
                }
            }    


        } 
                
        if (Input.GetKey(KeyCode.DownArrow) && (PosEsf1.z - Rad) > LimD)
        {
            if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.x - PosEsf2.x), 2) + Mathf.Pow((PosEsf1.z - PosEsf2.z), 2))) > (Rad2))
            {
                PosEsf1.z = PosEsf1.z - 1f;
            }
            else
            {
                if (LimD <= (PosEsf2.z - Rad) && (PosEsf2.z < PosEsf1.z))
                {
                    PosEsf2.z = PosEsf2.z - 1f;
                    PosEsf1.z = PosEsf1.z - 1f;
                }
                if (PosEsf2.z > PosEsf1.z)
                    PosEsf1.z = PosEsf1.z - 1f;

            }
        }     
               
        if (Input.GetKey(KeyCode.RightArrow) && (PosEsf1.x + Rad) < LimR)
        {
            
            if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) >(Rad2))
            {
                PosEsf1.x = PosEsf1.x + 0.05f;
            }
            else
            {
                if (LimR >= (PosEsf2.x + Rad) && (PosEsf2.x > PosEsf1.x))
                {
                    PosEsf2.x = PosEsf2.x + 0.05f;
                    PosEsf1.x = PosEsf1.x + 0.05f;
                }
                if (PosEsf2.x < PosEsf1.x)
                    PosEsf1.x = PosEsf1.x + 0.05f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (PosEsf1.x - Rad) > LimL)
        {
            
            if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) > (Rad2))
            {
                PosEsf1.x = PosEsf1.x - 0.05f;
            }
            else
            {
                if (LimL <= (PosEsf2.x - Rad) && (PosEsf2.x < PosEsf1.x))
                {
                    PosEsf2.x = PosEsf2.x - 0.05f;
                    PosEsf1.x = PosEsf1.x - 0.05f;
                }
                if (PosEsf2.x > PosEsf1.x)
                    PosEsf1.x = PosEsf1.x - 0.05f;

            }
        }      
                
        if (Input.GetKey(KeyCode.W)){
            LimU = LimU + 0.05f;
            LimD = LimD + 0.05f;
            if (LimD >= (PosEsf1.z - Rad))
            {
                PosEsf1.z = LimD+Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf2.z = PosEsf1.z + Rad2;
                }
            }
            if (LimD >= (PosEsf2.z - Rad))
            {
                PosEsf2.z = LimD + Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf1.z = PosEsf2.z + Rad2;
                }
            }
        }
        if (Input.GetKey(KeyCode.S)){
            LimU = LimU - 0.05f;
            LimD = LimD - 0.05f;
            if (LimU <= (PosEsf1.z+Rad))
            {
                PosEsf1.z = LimU-Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf2.z = PosEsf1.z - Rad2;
                }
            }
            if (LimU <= (PosEsf2.z + Rad))
            {
                PosEsf2.z =LimU-Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf1.z = PosEsf2.z - Rad2;
                }
            }
        }
        if (Input.GetKey(KeyCode.D)){
            LimR = LimR + 0.05f;
            LimL = LimL + 0.05f;
            if (LimL >= (PosEsf1.x - Rad))
            {
                PosEsf1.x = LimL+Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf2.x = PosEsf1.x + Rad2;
                }
            }
            if (LimL >= (PosEsf2.x - Rad))
            {
                PosEsf2.x = LimL + Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf1.x = PosEsf2.x + Rad2;
                }
            }
        }

        if (Input.GetKey(KeyCode.A)){
            LimR = LimR - 0.05f;
            LimL = LimL - 0.05f;
            if (LimR <= (PosEsf1.x + Rad))
            {
                PosEsf1.x = LimR-Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf2.x = PosEsf1.x - Rad2;
                }
            }
            if (LimR <= (PosEsf2.x + Rad))
            {
                PosEsf2.x =LimR-Rad;
                if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((PosEsf1.z - PosEsf2.z), 2) + Mathf.Pow((PosEsf1.x - PosEsf2.x), 2))) <= (Rad2))
                {
                    PosEsf1.x = PosEsf2.x - Rad2;
                }
            }

        }


        gameObject.GetComponent<Transform>().position = PosEsf1;

       




        Sphere2.GetComponent<Transform>().position = PosEsf2;

    }
}
