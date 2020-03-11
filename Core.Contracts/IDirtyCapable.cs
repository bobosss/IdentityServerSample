﻿using System.Collections.Generic;

namespace Allweb.Core.Common.Contracts
{

    public interface IDirtyCapable
    {

        bool IsDirty { get; }

        bool IsAnythingDirty();

        List<IDirtyCapable> GetDirtyObjects();

        void CleanAll();
    }
}


