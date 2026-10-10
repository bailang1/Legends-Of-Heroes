namespace ET
{
    public static class EntityExtensions
    {
        [EnableAccessEntiyChild]
        public static T GetOrAddComponent<T>(this Entity entity)
                where T : Entity, IAwake, new()
        {
            T component = entity.GetComponent<T>();
            return component ?? entity.AddComponent<T>();
        }
    }
}
