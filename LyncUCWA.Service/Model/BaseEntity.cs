using System;

namespace LyncUCWA.Service.Model
{
    public abstract class BaseEntity
    {
        public virtual string GetTag()
        {
            return String.Empty;
        }
    }
}