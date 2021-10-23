using Exiled.API.Features;
using JesusQC_Npcs.Features;
using UnityEngine;

namespace Pets.Features.Components
{
    public class PetController : MonoBehaviour
    {
        public Player Owner;
        public Dummy Dummy;

        private void Update()
        {
            if (Owner.Role == RoleType.Spectator)
            {
                Dummy.Destroy(true);
                return;
            }

            var moveDir = Owner.Position - Dummy.PlayerWrapper.Position;

            if (moveDir.magnitude > 10)
            {
                Dummy.PlayerWrapper.ReferenceHub.playerMovementSync.OverridePosition(Owner.Position, 0f, true);
            }
            else if (moveDir.magnitude > 2)
            {
                const int speed = 3;

                var movePos = Dummy.PlayerWrapper.Position + moveDir * speed * Time.deltaTime;
            
                Dummy.PlayerWrapper.ReferenceHub.playerMovementSync.OverridePosition(movePos, 0f, true);
            }
            
            var rot = Quaternion.LookRotation(moveDir.normalized);
            var rotation = new Vector2(rot.eulerAngles.x, rot.eulerAngles.y);

            Dummy.PlayerWrapper.Rotations = rotation;
        }
    }
}