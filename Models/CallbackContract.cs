using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevicesManager.ServiceReference;
using WcfService;

namespace DevicesManager.Models
{
    public class CallbackContract : IContractCallback
    {
        public void OnCallback()
        {

            throw new NotImplementedException();
        }
    }
}