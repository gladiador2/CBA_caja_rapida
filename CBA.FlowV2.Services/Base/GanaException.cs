using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBA.FlowV2.Services.Base
{
    public class GanaException : Exception
    {
        //private class GanaError
        //{
        //    private int mErrNo;
        //    private string mErrMsg;

        //    public int ErrNo 
        //    {
        //        get { return mErrNo; }
        //    }

        //    public string ErrMsg
        //    {
        //        get { return mErrMsg; }
        //    }

        //    public GanaError(int errNo, string errMsg)
        //    {
        //        mErrNo = errNo;
        //        mErrMsg = errMsg;
        //    }
        //}

        //public static const GanaError GanaErr_01 = new GanaError(0, "No se ha definido ninguna estancia");

        private const string DefaultMessage = "Error al efectuar la operación.";

        public GanaException() : base(DefaultMessage) { }

        public GanaException(string message) : base(message) { }

        public GanaException(Exception innerException) : base(DefaultMessage, innerException) { }

        public GanaException(string message, Exception innerException) : base(message, innerException) { }

    }
}
