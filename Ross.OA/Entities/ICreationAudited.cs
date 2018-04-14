namespace Ross.OA.Entities
{
    public interface ICreationAudited
    {
        long? CreatorUserId { get; set; }
    }
}
