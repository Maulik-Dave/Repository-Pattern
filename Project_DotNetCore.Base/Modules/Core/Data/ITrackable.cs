﻿using System;

namespace Project_DotNetCore.Base.Modules.Core.Data
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}