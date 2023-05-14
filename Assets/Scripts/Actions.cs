//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Actions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Actions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""GameActions"",
            ""id"": ""9dcb3253-c08d-44e0-ab87-a1b2a0ee1ee9"",
            ""actions"": [
                {
                    ""name"": ""Grab"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d6fc10ca-ad9e-42e7-8cfa-663eaec7bf3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dd9d952c-b0da-4084-b544-6377641ea7d4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e2f4345-5201-44bf-8629-f4cc7cc8afcb"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameActions
        m_GameActions = asset.FindActionMap("GameActions", throwIfNotFound: true);
        m_GameActions_Grab = m_GameActions.FindAction("Grab", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameActions
    private readonly InputActionMap m_GameActions;
    private IGameActionsActions m_GameActionsActionsCallbackInterface;
    private readonly InputAction m_GameActions_Grab;
    public struct GameActionsActions
    {
        private @Actions m_Wrapper;
        public GameActionsActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Grab => m_Wrapper.m_GameActions_Grab;
        public InputActionMap Get() { return m_Wrapper.m_GameActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActionsActions set) { return set.Get(); }
        public void SetCallbacks(IGameActionsActions instance)
        {
            if (m_Wrapper.m_GameActionsActionsCallbackInterface != null)
            {
                @Grab.started -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnGrab;
            }
            m_Wrapper.m_GameActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
            }
        }
    }
    public GameActionsActions @GameActions => new GameActionsActions(this);
    public interface IGameActionsActions
    {
        void OnGrab(InputAction.CallbackContext context);
    }
}