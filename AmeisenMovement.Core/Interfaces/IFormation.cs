using AmeisenMovement.Structs;

namespace AmeisenMovement.Interfaces
{
    public interface IFormation
    {
        Vector4 GetPosition(Vector4 inputPosition, double distance, int memberId, int memberCount);
    }
}