﻿using System.Collections.Generic;
using System;

namespace Tickify.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
    }
}