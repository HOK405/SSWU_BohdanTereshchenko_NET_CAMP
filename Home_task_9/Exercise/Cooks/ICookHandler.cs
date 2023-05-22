using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Cooks
{
    public delegate void OrderPreparedEventHandler(string message);
    public interface ICookHandler
    {
        public event OrderPreparedEventHandler OrderPrepared;
        public string LastName { get; set; }
        public bool IsBusy { get; set; }
        public ICookHandler SetNextCook(ICookHandler cook);
        public void HandleOrder(Order order);
    }
}
