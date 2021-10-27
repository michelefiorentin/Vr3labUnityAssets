using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class panel_interaction : MonoBehaviour
{
    // Start is called before the first frame update
    // vito non sa usare unity
    public GameObject Splash;
    public GameObject PannelloPrincipale;
    public GameObject testoestesoGO;
    public GameObject testoTitoloGO;
    private TextMeshProUGUI m_textpro_esteso;
    private TextMeshProUGUI m_textpro_titolo;
    private ConfigurableJoint myjont;
    private Animator myanim;
    public float maxtimebetweenclick =3; // guardia
    public float mytimer; // locat tiomecount
    bool b_time;
    void Start()
    {
        if (Camera.main == null) Debug.Log("MIssing a camera tagged main");
        m_textpro_esteso = testoestesoGO.GetComponent<TextMeshProUGUI>();
        m_textpro_titolo = testoTitoloGO.GetComponent<TextMeshProUGUI>();
        //if (m_textpro_Object == null) m_textpro_Object = GetComponentInChildren<TextMeshProUGUI>();
        //if (m_textpro_Object == null) print("NOT found TextMeshProUGUI");
        myjont = GetComponentInChildren<ConfigurableJoint>();
        if (myjont == null) print("NOT found SpringJoint2D");
        myanim = GetComponentInChildren<Animator>();
        if (myjont == null) print("NOT found Animator");

        mytimer = 0f;
        b_time = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && b_time  )
        {
            // b_time=false;// spostato al rigo 71 per consentire click multipli per colpire pesce
            Debug.Log("push");
                       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawLine(ray.origin, ray.origin + 100 * ray.direction, Color.cyan, 4);

            RaycastHit hit = new RaycastHit();
            //hit water surface
            // Check for a Wall.
            LayerMask peloliberomask = LayerMask.GetMask("pelolibero");
            // only layer 9 watersurface
            // old one if (Physics.Raycast(ray, out hit, 100f, peloliberomask))

            if (Collider.Raycast(ray, out hit, 100f, peloliberomask))
            {
                Debug.Log("rayhit pelolibero");
                Splash.transform.position = hit.point;
                Splash.SetActive(true);

                Debug.Log(hit.collider.gameObject.name);

            }else Debug.Log(" Raycast NOT watersurface");

            // check if hit the hittable 
            LayerMask hittablemask = LayerMask.GetMask("hittable");
            if (Physics.Raycast(ray, out hit, 100, hittablemask)) // only layer 8 is hit
            {
                b_time = false;// spostato dal rigo 46 per consentire click multipli per colpire pesce
                Debug.Log("rayhit level 8 -hittables");
                //CameraFading.CameraFade.In(2f);
                Debug.Log(hit.collider.gameObject.name);
                Educationaldata edu = hit.collider.gameObject.GetComponent<Educationaldata>();
                if (edu != null)
                {
                    Debug.Log("found edu:");
                    showtext(edu.getTitle(), edu.getRotatingCaption());
                    PannelloPrincipale.transform.position = hit.collider.transform.position;
                    if (hit.collider.attachedRigidbody)
                    {
                        myjont.connectedBody = hit.collider.attachedRigidbody;
                        myanim.SetTrigger("mostra_pannello");
                    }
                    else Debug.Log("NOT found attachedRigidbody");

                }
                else Debug.Log("NOT found edu");
            } else Debug.Log(" Raycast NOT hit nothing level 8 hittable");

        }
        else {
            mytimer += Time.deltaTime;
            if (mytimer > maxtimebetweenclick)
            {
                b_time = true;
                mytimer = 0;
                print("libero");
            }
        }
         


    }


    void showtext(string p_etichetta, string p_text)
    {
        // TextMesh
        m_textpro_esteso.text = p_text;
        m_textpro_titolo.text = p_etichetta;

    }

}
