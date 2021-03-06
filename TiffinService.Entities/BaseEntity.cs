﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AngularPOC.Entities
{
    public class BaseEntity
    {
    }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public class Entity<T> : BaseEntity, IEntity<T>
    {
        public T Id { get; set; }
    }
}
