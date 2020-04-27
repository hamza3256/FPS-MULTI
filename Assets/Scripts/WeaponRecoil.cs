using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [Header("Recoil_Transforms")]
    public Transform RecoilPosTranform;
    public Transform RecoilRotTranform;
    [Space(10)]
    [Header("Recoil_Settings")]
    public float PosDampTime;
    public float RotDampTime;
    [Space(10)]
    public float Recoil1;
    public float Recoil2;
    public float Recoil3;
    public float Recoil4;
    [Space(10)]
    public Vector3 RecoilRot;
    public Vector3 RecoilKickBack;

    public Vector3 RecoilRot_Scope;
    public Vector3 RecoilKickBack_Scope;
    [Space(10)]
    public Vector3 currRecoil1;
    public Vector3 currRecoil2;
    public Vector3 currRecoil3;
    public Vector3 currRecoil4;
    [Space(10)]
    public Vector3 RotOutput;

    public bool scoped = false;

   void Update()
    {
        scoped  = WeaponScope.isScoped;
    }

    void FixedUpdate()
    {

        currRecoil1 = Vector3.Lerp(currRecoil1, Vector3.zero, Recoil1 * Time.deltaTime);
        currRecoil2 = Vector3.Lerp(currRecoil2, currRecoil1, Recoil2 * Time.deltaTime);
        currRecoil3 = Vector3.Lerp(currRecoil3, Vector3.zero, Recoil3 * Time.deltaTime);
        currRecoil4 = Vector3.Lerp(currRecoil4, currRecoil3, Recoil4 * Time.deltaTime);

        RecoilPosTranform.localPosition = Vector3.Slerp(RecoilPosTranform.localPosition, currRecoil3, PosDampTime * Time.fixedDeltaTime);
        RotOutput = Vector3.Slerp(RotOutput, currRecoil1, RotDampTime * Time.fixedDeltaTime);
        RecoilRotTranform.localRotation = Quaternion.Euler(RotOutput);
    }
    public void Fire()
    {
        if (scoped == true)
        {
            currRecoil1 += new Vector3(RecoilRot_Scope.x, Random.Range(-RecoilRot_Scope.y, RecoilRot_Scope.y), Random.Range(-RecoilRot_Scope.z, RecoilRot_Scope.z));
            currRecoil3 += new Vector3(Random.Range(-RecoilKickBack_Scope.x, RecoilKickBack_Scope.x), Random.Range(-RecoilKickBack_Scope.y, RecoilKickBack_Scope.y), RecoilKickBack_Scope.z);
        }
        if (scoped == false)
        {
            currRecoil1 += new Vector3(RecoilRot.x, Random.Range(-RecoilRot.y, RecoilRot.y), Random.Range(-RecoilRot.z, RecoilRot.z));
            currRecoil3 += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);
        }
    }
}