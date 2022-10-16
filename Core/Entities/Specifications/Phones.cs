using Ardalis.Specification;

namespace BusinessLogic.Entities.Specifications
{
    public static class Phones
    {
        public class All : Specification<Phone>
        {
            public All()
            {
                Query
                    .Include(x => x.Color);
            }
        }
        public class ByIds : Specification<Phone>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Color);
            }
        }
        public class ById : Specification<Phone>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Color);
            }
        }
    }
}