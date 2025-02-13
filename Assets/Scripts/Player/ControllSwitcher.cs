using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllSwitcher : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider _moveProvider;
    [SerializeField] private TeleportationProvider _teleportationProvider;
    [SerializeField] private VisibilityTeleportController _visibilityTeleportController;

    [SerializeField] private bool _isTeleportMove;
    
    public void SetControllMode(bool isTeleportMove)
    {
        if (_isTeleportMove) { 
            _isTeleportMove = true;
            _moveProvider.enabled = false;
            _teleportationProvider.enabled = true;
            _visibilityTeleportController.enabled = true;
        }
        else
        {
            _isTeleportMove = false;
            _moveProvider.enabled = true;
            _teleportationProvider.enabled = false;
            _visibilityTeleportController.enabled = false;
        }
    }

    private void Start()
    {
        SetControllMode(_isTeleportMove);
    }
}
