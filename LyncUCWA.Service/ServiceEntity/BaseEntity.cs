using System;

namespace LyncUCWA.Service.ServiceCenter.Entity
{
    public abstract class BaseEntity
    {
        public virtual string GetTag()
        {
            return String.Empty;
        }
    }
}