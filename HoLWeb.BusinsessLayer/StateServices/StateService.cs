using HoLWeb.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLWeb.BusinessLayer.StateServices
{
    public class StateService<T> where T : class, new()
    {
        public T? Model { get; set; } = new T();
    }
}
