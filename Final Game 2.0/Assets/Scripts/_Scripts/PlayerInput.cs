using UnityEngine;
using UnityEngine.InputSystem;



namespace TarodevController {
    public class PlayerInput : MonoBehaviour {
        public FrameInput FrameInput { get; private set; }

        private void Update() {
            FrameInput = Gather();
        }

        private PlayerInputActions _actions;
        private InputAction _move, _jump, _dash, _attack;

        private void Awake() {
            _actions = new PlayerInputActions();
            _move = _actions.Player.Move;
            _jump = _actions.Player.Jump;
            _dash = _actions.Player.Dash;
            _attack = _actions.Player.Attack;
        }

        private void OnEnable() {
            _actions.Enable();
        }

        private void OnDisable() {
            _actions.Disable();
        }

        private FrameInput Gather() {
            return new FrameInput {
                JumpDown = _jump.wasPressedThisFrame(),
                JumpHeld = _jump.IsPressed(),
                DashDown = _dash.WasPressedThisFrame(),
                AttackDown = _attack.WasPressedThisFrame(),
                Move = _move.ReadValue<Vector2>()
            };
        }
    }

    public struct FrameInput {
        public Vector2 Move;
        public bool JumpDown;
        public bool JumpHeld;
        public bool DashDown;
        public bool AttackDown;
    }
}