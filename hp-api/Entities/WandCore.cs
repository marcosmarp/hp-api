﻿using hp_api.Interfaces;

namespace hp_api.Entities
{
    public class WandCore: IdNameInterface
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
