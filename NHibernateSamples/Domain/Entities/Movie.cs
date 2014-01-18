using System.Collections.Generic;

namespace Domain
{
    public class Movie : Product
    {
        public virtual string Director { get; set; }
        public virtual IList<ActorRole> Actors { get; set; }
    }
}
