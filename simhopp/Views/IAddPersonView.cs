using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void DelegateSaveAndNew();
    public delegate void DelegateSaveAndClose();

    public interface IAddPersonView
    {
        event DelegateSaveAndNew EventSaveAndNew;
        event DelegateSaveAndClose EventSaveAndClose;

    }
}
