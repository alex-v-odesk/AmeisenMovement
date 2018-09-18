using AmeisenMovement.Interfaces;
using AmeisenMovement.Structs;

namespace AmeisenMovement
{
    public class AmeisenMovementEngine
    {
        public int MemberCount { get; set; }
        public IFormation Formation { get; set; }

        public AmeisenMovementEngine(IFormation formation) { Formation = formation; }

        public Vector4 GetPosition(Vector4 inputPosition, double distance, int memberId)
        { return Formation.GetPosition(inputPosition, distance, memberId, MemberCount); }

    }
}
