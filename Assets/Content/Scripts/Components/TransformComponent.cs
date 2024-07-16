using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponent : AComponent
{
    private Transform transformComponent;

    private Quaternion currentRotation;
    private Quaternion targetRotation;

    private float translationX;
    private float translationZ;

    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private float smoothTime = 0.3f;

    //private XRInputManager inputManager;
    private bool isInitializeSuccesful = false;
    private float translateSpeed;

    private UIEditState currentEditState = UIEditState.NONE;


    public override void Initialize()
    {
        if (gameObject && gameObject.transform)
        {
            transformComponent = GetComponent<Transform>();
            currentRotation = transform.rotation;
            targetRotation = transform.rotation;

            translationX = 0;
            translationZ = 0;
        }
        else
        {
            isInitializeSuccesful = false;
        }

        /*
        inputManager = FindObjectOfType<XRInputManager>();
        if ( inputManager == null )
        {
            Debug.LogError("The Input Handler couldn't be found in the scene ! ");
            isInitializeSuccesful = false;
            return;
        }
        */

        isInitializeSuccesful = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (isInitializeSuccesful)
        {
            switch (TransformStateManager.Instance.GetTransformState())
            {
                case UIEditState.TRANSLATE:
                    Translate();
                    break;
                case UIEditState.ROTATE:
                    Rotate();
                    break;
                case UIEditState.SCALE:
                    Scale();
                    break;
                case UIEditState.NONE:
                default:
                    // No transformation action
                    break;
            }
        }
    }

    public void SetTransform(Transform transform)
    {
        this.transformComponent = transform;
    }

    public Transform GetTransform()
    {
        return transformComponent;
    }

    private void Translate()
    {
        //translationX += inputManager.translateInputX * translateSpeed * Time.deltaTime;
        //translationZ += inputManager.translateInputZ * translateSpeed * Time.deltaTime;
        //transformComponent.Translate(new Vector3(translationX, 0, translationZ), Space.Self);
    }

    private void Rotate()
    {

        //targetRotation *= Quaternion.Euler(inputManager.rotationInputX * rotationSpeed * Time.deltaTime,
        //                                   inputManager.rotationInputY * rotationSpeed * Time.deltaTime,
        //                                   0);
        //currentRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime / smoothTime);
        //transform.rotation = currentRotation;
    }

    private void Scale()
    {
        //if (inputManager.scaleInputUp > 0)
        //{
        //    transformComponent.localScale += inputManager.scaleInputUp * Vector3.one * Time.deltaTime;
        //}

        //if (inputManager.scaleInputDown > 0)
        //{
        //    transformComponent.localScale -= inputManager.scaleInputDown * Vector3.one * Time.deltaTime;
        //}
    }

    public void SetRotation(float rotationX, float rotationY)
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    public void SetTranslation(float positionX, float positionZ)
    {
        transform.localPosition = new Vector3(positionX, 0, positionZ);
    }

    public void SetScale(float scaleValue)
    {
        transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void ResetTransform()
    {
        transform.rotation = Quaternion.identity;
        SetScale(1);
        SetTranslation(0, 0);
    }
}
