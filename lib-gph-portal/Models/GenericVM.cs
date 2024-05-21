using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sa.gov.libgph.Models
{

    public class GenericVM<T> 
    {
        private readonly ResponseStatusEnum status;
        //private IMessageList messages;
        private T data;
        private int dataLength;

        public GenericVM(ResponseStatusEnum status, T data, int dataLength = 0)
        {
            this.status = status;
            //this.messages = messages;
            this.data = data;
            this.dataLength = dataLength;
        }
        public T Data => data;

        //public IMessageList Messages => messages;

        public ResponseStatusEnum Status => status;
        public int DataLength => dataLength;

    }
}